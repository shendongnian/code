     public Type CreateDataHandler(string requestName)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            foreach (Module _module in _assembly.Modules)
            {
                if (_module.GetTypes().Length > 0)
                {
                    foreach(Type _type in _module.GetTypes())
                    {
                        if (_type.CustomAttributes.Count() > 0)
                        {
                            CustomAttributeData _customAttribute = _type.CustomAttributes.SingleOrDefault(a => a.AttributeType == typeof(DataExchangeItem));
                            if (_customAttribute != null)
                            {
                                foreach (var _argument in _customAttribute.ConstructorArguments)
                                {
                                    if (_argument.Value.ToString() == requestName)
                                    {
                                        return _type;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
