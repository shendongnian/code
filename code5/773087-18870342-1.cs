    public static object GetDeepPropertyValue(object src, string propName)
        {
            if (propName.Contains('.'))
            {
                string[] Split = propName.Split('.');
                string RemainingProperty = propName.Substring(propName.IndexOf('.') + 1);
                return GetDeepPropertyValue(src.GetType().GetProperty(Split[0]).GetValue(src, null), RemainingProperty);
            }
            else
                return src.GetType().GetProperty(propName).GetValue(src, null);
        }
  
