    public static class Extensions
    {
        public static string DisplayPerson<T>(this T source)
        {
            if(source == null) throw new ArgumentNullException("source");
            var flags = BindingFlags.Instance | BindingFlags.Public;
            var properties = source.GetType().GetProperties(flags);
            if (properties.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (var prop in properties)
                {
                    sb.AppendFormat("{0} : {1}", prop.Name, prop.GetValue(source));
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            return string.Empty;
        }
    }
