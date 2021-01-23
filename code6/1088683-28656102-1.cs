    class Program
    {
        static void Main(string[] args)
        {
            var cv = new ConverterDictionary();
            var type2_converter = cv.GetConverter<Type2, Type2_New>();
            var converterF = type2_converter.Compile();
            var type2 = new Type2 { Field1 = "Hello", Field2 = "World" };
            var type2_New = converterF(type2);
        }
    }
    public class ConverterDictionary
    {
        private Dictionary<Tuple<Type, Type>, object> conversionDict = new Dictionary<Tuple<Type, Type>, object>();
        public ConverterDictionary()
        {
            var convertPairs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(ClassConvertAttribute)))
                .Select(t => Tuple.Create(t, (Type)(t.CustomAttributes.First().NamedArguments[0].TypedValue.Value)))
                .ToList();
            foreach(var pair in convertPairs)
            {
                var fromType = pair.Item1;
                var toType = pair.Item2;
                var fieldConversions = fromType.GetFields()
                    .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(FieldConvertAttribute)))
                    .Select(f => Tuple.Create(f, toType.GetField((string)(f.CustomAttributes.First().NamedArguments[0].TypedValue.Value))))
                    .ToList();
                var delegateType = typeof(Func<,>).MakeGenericType(fromType, toType);
                var param1 = Expression.Parameter(fromType, "oldInst");
                var returnVar = Expression.Variable(toType, "newInst");
                var expr = Expression.Lambda(
                    delegateType,
                    Expression.Block(
                        new ParameterExpression[] { returnVar },
                        new Expression[]
                        {
                            Expression.Assign(
                                returnVar,
                                Expression.New(toType)
                            ),
                        }.Concat(
                            fieldConversions.Select(fc => 
                                Expression.Assign(
                                    Expression.MakeMemberAccess(
                                        returnVar,
                                        fc.Item2
                                    ),
                                    Expression.MakeMemberAccess(
                                        param1,
                                        fc.Item1
                                    )
                                )
                            )
                        ).Concat(
                           new Expression[] { returnVar }
                        )
                    ),
                    param1
                );
                conversionDict[pair] = expr;
            }
        }
        public Expression<Func<TFrom, TTo>> GetConverter<TFrom, TTo>()
        {
            var key = Tuple.Create(typeof(TFrom), typeof(TTo));
            if (conversionDict.ContainsKey(key))
                return conversionDict[key] as Expression<Func<TFrom, TTo>>;
            return null;
        }
    }
    [ClassConvert(ToType=typeof(Type1_New))]
    public class Type1
    {
        [FieldConvert(ToFieldName = "Field1")]
        public string Field1;
    }
    [ClassConvert(ToType = typeof(Type2_New))]
    public class Type2
    {
        [FieldConvert(ToFieldName="Field1")]
        public string Field1;
        [FieldConvert(ToFieldName = "Field2_New")]
        public string Field2;
    }
    public class Type1_New
    {
        public string Field1;
    }
    public class Type2_New
    {
        public string Field1;
        public string Field2_New;
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class ClassConvertAttribute : Attribute
    {
        public Type ToType { get; set; }
    }
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FieldConvertAttribute : Attribute
    {
        public string ToFieldName { get; set; }
    }
