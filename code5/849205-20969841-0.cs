    List<TimesheetError> errors = new List<TimesheetError>();
    if (client.Name.IsEmpty())
    {
        TimesheetError error = new TimesheetError();
        error.Messsage = "Bad request";
        error.ListErrors = "name is not enterd";
        error.Status = "Not Found";
        error.IsNotValid = true;
        errors.Add(error);
    }
    
    if (client.Contact.FirstName.IsEmpty())
    { 
        TimesheetError error = new TimesheetError();
        error.Messsage = "Bad Request";
        error.ListErrors = "Contact name is not entered";
        error.Status = "Not Found";
        error.IsNotValid = true;
    }
    
    return errors
