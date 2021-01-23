    public static class ControllerStringExtension
    {
        private const string ControllerString = "Controller";
        public static string Short(this string value)
        {
            if (value.EndsWith(ControllerString))
            {   
                //Remove 'Controller' from end of value name.             
                return value.Remove(value.Length - ControllerString.Length);
            }
            throw new ApplicationException("Should be used only for Controller names.");
        }
    }
