    public  List<TimeSheetError> Validate(Client client)
        {
              List<TimeSheetError> error = new List<TimeSheetError>();
            //TimesheetError error = new TimesheetError();
          
            if (client.Name.IsEmpty())
            {  
           		TimesheetError error1 = new TimesheetError();
                error1.Messsage = "Bad request";
                error1.ListErrors = "name is not enterd";
                error1.Status = "Not Found";
                error1.IsNotValid = true;
    error.add(error1);
            }
             if (client.Contact.FirstName.IsEmpty())
            {
                TimesheetError error2 = new TimesheetError(); 		
           		error2.Messsage = "Bad Request";
                error2.ListErrors = "Contact name is not entered";
                error2.Status = "Not Found";
                error2.IsNotValid = true;
           error.add(error2)
            }
    		
            return error
