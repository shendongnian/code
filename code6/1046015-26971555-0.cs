        public void Execute(string methodName, ExpandoObject values)
        {
            // ...
           
            if(values.Any(x => x.Key == methodParameterProperties[0].Name))
            {
                var value = values.First(x => x.Key == methodParameterProperties[0].Name).Value;
                 // build argument here (based on value)
            }
        }
