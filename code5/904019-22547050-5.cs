    Assembly asm = Assembly.LoadFrom(strDLL);
    string calcInterfaceName = typeof(ICalculator).FullName;
    foreach (Type type in asm.GetExportedTypes()) {
        Type interfaceType = type.GetInterface(calcInterfaceName);
        if (interfaceType != null &&
            (type.Attributes & TypeAttributes.Abstract) != TypeAttributes.Abstract) {
            ICalculator calculator = (ICalculator)Activator.CreateInstance(type);
            int result = calculator.Add(2, 7);
        }
    }
