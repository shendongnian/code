    public static void OnCreate<T>(T arg)
    {
            var type = arg.GetType();
            var birthDateProperty = type.GetProperty("BirthDate");
            if (birthDateProperty == null)
                throw new ArgumentException("Argument not is implementing the model");
            birthDateProperty.SetValue(arg, DateTime.Now);
            //And so on...
    }
