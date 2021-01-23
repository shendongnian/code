        public static class Factory
    {
        public static T GetAut<T>()
        {
            T autPar = Activator.CreateInstance<T>();
            System.Reflection.FieldInfo[] fi = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fi)
            {
                switch (field.Name)
                {
                    case "pwField":
                        field.SetValue(autPar, ConfigurationService.pw);
                        break;
                }
            }
            return autPar;
        }
