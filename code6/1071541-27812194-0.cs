    var user = new User(){UserName="ABC", Password="123"};
    user.UserContacts = new UserContacts();
    user.UserContacts.Add(new UserContacts(){ PhoneNumber = "9087654321"});
    user.UserContacts.Add(new UserContacts(){ PhoneNumber = "5412309876"});
    
    Context.Users.Add(user);
    Context.SaveChanges();
