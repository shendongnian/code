        private Dictionary<Type, Mock> mocks;
        private void SetupCreateFoo<T>(Mock<IMyFactory> myFactory) where T: MyBaseClass 
        {
            var t = typeof(T);
            var constructors = from constructor in t.GetConstructors()
                               let parameters = constructor.GetParameters()
                               where parameters.Length > 0
                               select new { constructor, parameters };
            
            // Note: there should only be one constructor anyway           
            foreach (var c in constructors)
            {
                List<object> parameters = new List<object>();
                foreach (var p in c.parameters)
                {
                    parameters.Add(mocks[p.ParameterType].Object);
                }
                myFactory.Setup(d => d.CreateAnalytic<T>()).Returns((T)c.constructor.Invoke(parameters.ToArray()));
            }
        }
