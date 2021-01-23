    IAccessRightsManager stubAccessRights = new 
        MockRepository.GenerateStub<IAccessRightsManager>(); 
    stubAccessRights.Stub(ar => ar.canUserRead((IUser)null, confidentialDocument))
        .Return(false);  
    stubAccessRights.Stub(ar => ar.canUserRead((IUser)null, nonConfidentialDocument))
        .Return(true); 
