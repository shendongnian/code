            // Helper.cs
            public static Action<TType> Wrap<TType>(Delegate test)
            {
                return ret => test.DynamicInvoke();
            }
    
           var meth = typeof(Helper).GetMethod("Wrap");
           var gmeth = meth.MakeGenericMethod(new[] { serviceT });
           var genericAction = gmeth.Invoke(null, new object[] { 
                    Expression.Lambda(methodCall).Compile(); });
