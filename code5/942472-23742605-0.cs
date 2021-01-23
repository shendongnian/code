    foreach (var emailItem in myEmailObjects)
    {
        if (emailItem is Person)
        {
            SendEmail(from, to, GetSubject((Person)emailItem), 
                GetMessage((Person)emailItem));
        }
        else if (emailItem is VacationDay)
        {
            SendEmail(from, to, GetSubject((VacationDay)emailItem), 
                GetMessage((VacationDay)emailItem));
        }
                
    }
