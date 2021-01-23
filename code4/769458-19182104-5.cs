    foreach (var validationResults in db.GetValidationErrors())
    {
        foreach (var error in validationResults.ValidationErrors)
        {
            Debug.WriteLine("Entity Property: {0}, Error {1}",
                              error.PropertyName,error.ErrorMessage);
        }
    }
