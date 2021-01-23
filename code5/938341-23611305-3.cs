    foreach( KeyValuePair<string, object> property in 
                new Dictionary<string, object>
                { { "RegistrationAddress", model.RegistrationAddress}
                , { "ResidenceAddress", model.ResidenceAddress } ...
                }
            )
    {
        // alter each of the given properties...
    }
