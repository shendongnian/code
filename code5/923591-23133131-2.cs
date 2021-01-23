    public List<EmailItem> TodayEmails(List<EmailItem> emailArray)
    {
        foreach(var emailItem in emailArray)
        {
           if(emailItem.RecievedDate.Date == DateTime.Today.Date)
           {
               yield return emailItem;
           }
        }
    }
