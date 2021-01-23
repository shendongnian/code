    using (var proxy = ProxyHelper.GetOrganizationServiceProxy())
    {
        var setStateReq = new SetStateRequest
        {
            EntityMoniker = new EntityReference("new_entityname", 
            entityname.new_entitynameid),
            State = new OptionSetValue(1),
            Status = new OptionSetValue(2),
        };
        proxy.Execute(setStateReq);
    }
