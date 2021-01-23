    public TimesheetError Validate(Client client)
    {
        TimesheetError error = new TimesheetError();
        if (client.Name.IsEmpty())
        { 
           error.Messsage = "Bad request";
            error.ListErrors = "name is not enterd";
            error.Status = "Not Found";
            error.IsNotValid = true;
        }
         if (client.Contact.FirstName.IsEmpty())
        { error.Messsage += " Bad Request";
            error.ListErrors += " Contact name is not entered";
            error.Status += " Not Found";
            error.IsNotValid += true;
        }
        return error
