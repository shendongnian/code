        public static T LogValue<T>(T val)
        {
            Console.WriteLine(val.GetType().Name + ": " + val);
            return val;
        }
        static void Main(string[] args)
        {
            Expression myColValueFromTheDatabase = Expression.Convert(Expression.Constant(1234L), typeof(object));
            myColValueFromTheDatabase = Expression.Call(typeof(Program), "LogValue", new[] { myColValueFromTheDatabase.Type }, myColValueFromTheDatabase); //log
            Expression unboxed = Expression.Convert(myColValueFromTheDatabase, typeof(long));
            Expression converted = Expression.Convert(unboxed, typeof(uint));
            var result = Expression.Lambda<Func<uint>>(converted).Compile()();
            Console.WriteLine(result);
        }
