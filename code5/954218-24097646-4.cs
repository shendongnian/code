As an example for Async Operation :
    public async Task<bool> login(string usn, string pwd)
    {
        DataClasses1DataContext auth = new DataClasses1DataContext();
        var message = await (from p in auth.Users
                      where p.usrName == usn && p.usrPass == pwd
                      select p).ToListAsync();
        if (message.Count() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
