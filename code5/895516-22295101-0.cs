    private async Task CalculateAsync()
    {
        Task<double> returnTaskObject = await Task<double>.Factory.StartNew(
        (pObjectHoldingValues)  => Calculate(pObjectHoldingValues), parameterObject);
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
