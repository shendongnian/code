    Plugins.Add(new ValidationFeature
    {
        ErrorResponseFilter = CustomValidationError
    });
    
    ...
    
    private object CustomValidationError(ValidationResult validationResult, object errorDto)
    {
        var firstError = validationResult.Errors.First();
        return new HttpError(HttpStatusCode.Conflict, firstError.ErrorCode, firstError.ErrorMessage);
    }
