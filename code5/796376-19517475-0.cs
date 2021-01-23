    stubAccessRights
        .Stub(ar => ar.canUserRead(Arg<IUser>.Is.Null, confidentialDocument))
        .Return(false);
    stubAccessRights
        .Stub(ar => ar.canUserRead(Arg<IUser>.Is.Null, nonConfidentialDocument))
        .Return(true);
