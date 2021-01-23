    List<Users> SessionList = new List<Users>();
    if (SessionList.Where(x => x.Title == System.Environment.MachineName).Count() == 0) {
    	Users TempUser = default(Users);
    	TempUser.Title = My.Computer.Name;
    	SessionList.Add(TempUser);
    	Application("SessionList") = SessionList;
    }
