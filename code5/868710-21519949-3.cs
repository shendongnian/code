        public static class ObjectHelper<TIn, TOut>
            where TOut : class, new()
            where TIn : HasJson
        {
            // This Lambda is not generic; it'll work wherever you put it :)
            public static Func<DateTime> Now = () => DateTime.Now;
            // Clone takes TIn, and returns the output of Deserialize, which is TOut;
            // Therefore Clone and Deserialize will have the same generic type parameters
            public static Func<TIn, TOut> Clone = obj => Deserialize(obj);
            // calling obj.Json only possible due to where TIn: HasJson constraint above
            public static Func<TIn, TOut> Deserialize = obj => FakeBSON(obj.ToJson());
            // Just to test a method call in the generic lambda, meant to mimic what BSONSerializer 
            // does and allow my test code to compile without having BSONSerializer available
            static TOut FakeBSON(string json)
            {
                var res = new TOut();
                return res;
            }
        }
