    public  void UpdateLocation(string usrName, double usrLong, double usrLat)
    {
    using(DataClasses1DataContext Usercontext = new DataClasses1DataContext())
       {
       var result = (from usr in Usercontext.Users
       where usr.usrName == usrName
       select usr).Single();
       result.usrLong = usrLong;
       result.usrLat = usrLat;
       Usercontext.SubmitChanges();
       }
    }
