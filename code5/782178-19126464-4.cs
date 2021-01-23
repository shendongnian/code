    const int DefaultMaxValue = 20;
    
    public void ExampleMethod(int? maxValue = DefaultMaxValue)
    {
        maxValue.Dump();
    }
    ExampleMethod(param < 20 ? param : DefaultMaxValue);
