    IAccessRightsManager stubAccessRights = new 
        MockRepository.GenerateStub<IAccessRightsManager>(); 
    
    stubAccessRights.Stub(ar => ar.canUserRead(Arg<IUser>.Is.Anything, confidentialDocument))
        .Return(false);  
    stubAccessRights.Stub(ar => ar.canUserRead(Arg<IUser>.Is.Anything, nonConfidentialDocument))
        .Return(true); 
