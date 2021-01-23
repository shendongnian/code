    var userName = context.UserName;
    var password = context.Password;
    var userService = new UserService(); // our created one
    var user = userService.ValidateUser(userName, password);
    if (user != null){
       .......
    }
