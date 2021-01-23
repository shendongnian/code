    Abstract_Entity ae = new Abstract_Entity();
    Entities.Abstract_Entity.Add(ae);
    Entities.SaveChanges();
    
    User u = new User();
    u.email = email;
    u.userID = ae.ID;
    Entities.User.Add(u);
    Entities.SaveChanges(); 
