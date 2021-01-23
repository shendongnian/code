    interface ISomeInterface {
        PropA { get; set; }
        PropB { get; set; }
    }
    private T MapClass<T>(ISomeInterface inputClass)
        where T : ISomeInterface, new()
    {
        T outputClass = new T();
        outputClass.PropA = inputClass.PropA;
        outputClass.PropB = inputClass.PropB;
        ...
        return outputClass;
    }
