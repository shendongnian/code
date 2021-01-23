    public static class Utils 
    {
        public static void CopyFields<T>(T source, T destination)
        {
            var fields = source.GetType().GetFields();
            foreach(var field in fields)
            {
                field.SetValue(destination, field.GetValue(source));    
            }            
        }
    }
