    [OperationContract]
    public bool login(string usn, string pwd)
    {
        DataClasses1DataContext auth = new DataClasses1DataContext();
        var message = from p in auth.Users
                        where p.usrName == usn && p.usrPass == pwd
                        select p;
        if (message.Count() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
