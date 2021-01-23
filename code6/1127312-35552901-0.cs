    public static class ControllerStringExtension
    {
        private const string ControllerString = "Controller";
        public static string Short(this string value)
        {
            if (value.EndsWith(ControllerString))
            {                
                return value.Remove(value.Length - ControllerString.Length);
            }
            throw new ApplicationException($"Extension method {nameof(ControllerStringExtension)}.{nameof(Short)} should be used only for Controller names. Strings which ends with {ControllerString}");
        }
    }
