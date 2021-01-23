    private void Send()
    {
        Parallel.Foreach(GetAllUsers(), user => 
        {
           SendMail(user.Email);
        });
    }
