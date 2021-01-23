    class1.Sport = CreateProp1(prop2);
    
    private Prop1 CreateProp1(bool initialBoolValue)
    {
       return new Prop1()
       {
          BoolValue = initialBoolValue;
       }
    }
