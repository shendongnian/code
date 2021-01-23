        public MyConverter(IConnectionSettingsValues connectionSettings)
            : base(connectionSettings)
        {
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            if (objectType.Assembly.FullName.Contains("MyDefinition") && objectType.IsInterface)
            {
                var name = objectType.Name;
                //Check if name starts with an 'I' and the second char is a UpperCase aswell to be sure the given Type.Name is a interface.
                if (name.StartsWith("I") && char.IsUpper(name[1]))
                {
                    //Remove the I from the name
                    name = name.Substring(1);
                    Assembly assembly = Assembly.Load(<MyAssembly>);
                    Type t = assembly.GetType("MyNamespace" + name);
                    if (t != null)
                    {
                        objectType = t;
                    }
                }
            }
            var baseReturn = base.CreateContract(objectType);
            return baseReturn;
        }
    }
