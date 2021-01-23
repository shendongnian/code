    var user = new User();
    
    var applicationId = Cast.To<int>(userModel.Application);
    
    //                behind is session.Get<Aplication>(applicaitonId)
    var application = applicationService.GetById(applicationId);
    
    if(application !== null)
    {
        application.ApplicationName = ... // here we can even change that;
        user.Application = application;
    }
