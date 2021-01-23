    public void Execute(IServiceProvider provider)
    {
        var context = provider.GetContext();
        var service = provider.GetService(context);
        var target = GetTarget<Contact>(context);
        if (target == null || !target.ContainsAllNonNull(c => new
            {
                c.FirstName,
                c.LastName,
            }))
        {
            // Entity is of the wrong type, or doesn't contain all of the required attributes
            return;
        }
        
        ExecutePlugin(service, target);
    }
    public void ExecutePlugin(IOrganizationService service, Contact target){
        // Logic Goes Here
    }
