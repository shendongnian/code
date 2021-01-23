        private List<T> CastGenericToEF<T>(List<GenericClass> GenericList) where T : IGenericClass, new()
        {
            List<T> Target = new List<T>();
            foreach (var generic in GenericList)
            {
                //How can I do to create an Instance of T?
                var tInstance = new T();
                tInstance.SomeMethod();
                // Some proccess here 
                var typeOf = typeof(T);
            }
            return Target;
        }
