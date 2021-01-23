    public void MyMethod()
    {
        var username= GetUniqueUserName();
        MyImplementation(username);
    }
    
    private void MyImplementation(string userName)
    {
        if (!UtilityRepository.CheckUserName(username))
        {
            MyImplementation(userName);
            return;
        }
        //actual stuff here
    }
