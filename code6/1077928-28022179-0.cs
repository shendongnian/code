    public void ValidateWithoutThrow_ReturnsSucessfulResult_When_RequestIsValid() 
    {
        var validRequest = //...
        var validator = new TerminationRequestValidation(/*...*/); // don't mock this class
    
        var result = validator.TerminationRequestValidation(validRequest);
    
        Assert.Equal(ValidationResult.Success, result);
    }
    
    public void ValidateWithoutThrow_ReturnsUnsucessfulResult_When_RequestIsInvalid() 
    {
        var invalidRequest = //...
        var validator = new TerminationRequestValidation(/*...*/); // don't mock this class
    
        var result = validator.TerminationRequestValidation(invalidRequest);
    
        Assert.NotEqual(ValidationResult.Success, result);
    }
