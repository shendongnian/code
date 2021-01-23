    public void Update(string customLabel, bool isVisible, int orderNumber)
    {
        if (!MyValidationMethod())
        {
            throw new MyCustomException();
        }
        CustomLabel = customLabel;
        IsVisible = isVisible; 
        OrderNumber = orderNumber;
        PerformMyAdditionalProcessingThatIAlwaysWantToHappen();
    }
