        public class TypeArgumentInferenceEngine
        {
            public Dictionary<Type, Type> ParameterToConcrete = new Dictionary<Type, Type>();
            public void MatchTypes(Type concrete, Type generic)
            {
                if (generic.IsGenericParameter)
                {
                    if (ParameterToConcrete.ContainsKey(generic))
                    {
                        var tmp = ParameterToConcrete[generic];
                        if (!tmp.Equals(concrete))
                            throw new Exception(String.Format("Template parameter {0} is inconsistent between {1} and {2}", generic, concrete, tmp));
                    }
                    else
                    {
                        ParameterToConcrete.Add(generic, concrete);
                    }
                }
                else if (generic.IsGenericType) 
                {
                    if (!concrete.IsGenericType)
                        throw new Exception("Expected generic concrete type");
                    var concreteTypeArgs = concrete.GetGenericArguments();
                    var genericTypeArgs = generic.GetGenericArguments();
                    if (concreteTypeArgs.Length != genericTypeArgs.Length)
                        throw new Exception("Mismatched number of generic argument types");
                    for (int i = 0; i < genericTypeArgs.Length; ++i)
                        MatchTypes(concreteTypeArgs[i], genericTypeArgs[i]);
                }
            }
            public static Dictionary<Type, Type> InferTypeParameters(Type[] concreteTypes, Type[] genericTypes)
            {
                var engine = new TypeArgumentInferenceEngine();
                int n = concreteTypes.Length;
                if (n != genericTypes.Length) throw new ArgumentException("Both input arrays have to be the same size");
                for (int i = 0; i < n; ++i)
                    engine.MatchTypes(concreteTypes[i], genericTypes[i]);
                foreach (var t in engine.ParameterToConcrete.Keys)
                    if (!t.IsGenericParameter)
                        throw new Exception("Expected a generic type parameter");
                return engine.ParameterToConcrete;
            }
            public static MethodInfo MakeGenericMethodFromArgTypes(MethodInfo mi, params Type[] argTypes)
            {
                if (!mi.IsGenericMethodDefinition)
                    return mi;
                var typeParams = mi.GetGenericArguments();
                var paramTypes = mi.GetParameters().Select(p => p.ParameterType).ToArray();
                var typeLookup = InferTypeParameters(argTypes, paramTypes);
                var typeArgs = new List<Type>();
                foreach (var p in typeParams) 
                {
                    if (!typeLookup.ContainsKey(p))
                        throw new Exception(String.Format("Type parameter {0} is not bound: ", p));
                    typeArgs.Add(typeLookup[p]);
                }
                return mi.MakeGenericMethod(typeArgs.ToArray());
            }
        }
        public static void TestTypeDeduction()
        {
            var t1 = typeof(IArray<int>);
            var t2 = typeof(Func<int, bool>);
            // Map has the type "Func<IArray<T> xs, Func<T, U>, IArray<U>>"
            var genericMethod = typeof(Ops).GetMethod("Map");
            var concreteMethod = TypeArgumentInferenceEngine.MakeGenericMethodFromArgTypes(genericMethod, t1, t2);
            Console.WriteLine("{0}, {1} => {2}", t1, t2, concreteMethod.ReturnType);
       
            //var nonGenericMethod = genericMethod.MakeGenericMethod(typeArgs.ToArray());
        }
