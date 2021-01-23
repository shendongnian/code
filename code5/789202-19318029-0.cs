    var user = server.GetUser("edokan");
    user.Alias = "edokan2";
    
    var user2 = server.GetUser("edokan");
    //user.Alias == user2.Alias; // is false
