     public static string messageParser(string id)
    {
        ApplicationDbContext db = new ApplicationDbContext();
        var ApplicationDbContext = new ApplicationDbContext();
        var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
        var user = UserManager.FindById(id);
        string final = "";
        var list =  user.Message.ToList();
        foreach (var item in list)
        {
            final += item.notification + "\n\n";
            db.Message.Remove(item);
            db.SaveChanges();
        }   
       
        return final;
