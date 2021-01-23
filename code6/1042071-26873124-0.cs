    public static Dictionary<string, object> ToDictionary(this Exception ex)
        {
            var exceptionData = ex.GetType()
                   .GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.Name != "InnerException")
                   .ToDictionary(prop => prop.Name, prop => prop.GetValue(ex, null));
            
            exceptionData.Add("Type", ex.GetType().ToString());
            if (ex.InnerException != null)
            {
                var innerExceptionData = ex.InnerException.ToDictionary();
                if ((exceptionData != null) && (innerExceptionData != null))
                {
                    foreach (var keyPair in innerExceptionData)
                    {
                        exceptionData.Add(string.Format("InnerException.{0}", keyPair.Key), keyPair.Value);
                    }
                } 
            }
            return exceptionData;
        }
