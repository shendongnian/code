    private List<string[]> findUser(string strUser)
    {
        List<string[]> list = new List<string[]>();
        GetXASessionByFarm sessions = new GetXASessionByFarm(true);
        
        sessions.Full = true;
        
        foreach (XASession session in CitrixRunspaceFactory.DefaultRunspace.ExecuteCommand(sessions))
        {
            if (session.AccountName == objWINS + "\\" + strUser)
            {
                string[] result = new string[3];
                result[0] = strUser;
                result[1] = session.ServerName; //This is working, it comes back with the server name.
                result[2] = session.ClientAddress; //This isn't working, it comes back blank.
                MessageBox.Show(result[2]);
                list.Add(result);
            }
        }
        return list;
    }
