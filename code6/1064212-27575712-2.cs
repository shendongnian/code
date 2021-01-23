    public static string messageParser(string id)
    {
        ApplicationDbContext db = new ApplicationDbContext();
        var UserManager = new UserManager<User>(new UserStore<User>(db));
        var user = UserManager.FindById(id);
        string final = "";
        var list =  user.Message.ToList();
        foreach (var item in list)
        {
            final += item.notification + "\n\n";
        }   
       db.Message.Remove(user);
       db.SaveChanges();
       
       return final;
    }
