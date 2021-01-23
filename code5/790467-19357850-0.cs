    public List<ValidationError> ValidationErrors = new List<ValidationError>();
    
    private void Window_Error(object sender, ValidationErrorEventArgs e)
    {
        if (e.Action == ValidationErrorEventAction.Added)
            ValidationErrors.Add(e.Error);
        else
            ValidationErrors.Remove(e.Error);
    }
