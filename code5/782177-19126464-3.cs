    public void ExampleMethod(int? maxValue = null)
    {
        if(maxValue.HasValue)
            maxValue = 20;
    }
    ExampleMethod(param < 20 ? (int?)param : null);
