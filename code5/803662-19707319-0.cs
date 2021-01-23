    Abstract_Entity entity = new Abstract_Entity();
    entity.ID = Guid.NewGuid();
    
    User user = new User();
    //fill with user data
    user.userID = entity.ID;
    
    MyContext db = new MyContext();
    db.Abstract_Entitys.Attach(entity);
    db.Users.Attach(user);
    db.SubmitChanges();
