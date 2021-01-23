    private async Task CalculateAsync()
    {
        Task<double> returnTaskObject = await Task<double>.Factory.StartNew(
                 (paramsHoldingValues)  => Calculate(paramsHoldingValues), 
                 customParameterObject);
        
        // Because of await the following lines will only be executed 
        // after the task is completed while the caller thread still has 'focus'
        double result = returnTaskObject.Result;
        Validate(result);
    }
    private double Calculate(CustomArgsObject values)
    {
        return values.Value1 + values.Value2;
    }
    private bool Validate(double value)
    {
        return (value < 1000);
    }
