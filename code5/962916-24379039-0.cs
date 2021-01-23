    var user = new User();
    
    var applicationId = Cast.To<int>(userModel.Application);
    
    //                behind is session.Load<Aplication>(applicaitonId)
    var application = applicationService.Load(applicationId);
    
    user.Application = application;
    userService.Add(user);
