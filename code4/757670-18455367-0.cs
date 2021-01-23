    public CalculatorBase CreateClass(string typeName)
    {
        var type = Type.GetType(string.Format("NameSpaceCalculator.{0}",typeName));
        return (CalculatorBase)Activator.CreateInstance(type);
    }
