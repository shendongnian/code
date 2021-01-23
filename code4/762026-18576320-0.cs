    C#(this is not working)
    List<string> Roles = new List<string>();
    for (int x = 0; x <= EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer.CustomerRoles.Count - 1; x++) {
        Roles.Add(EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer.CustomerRoles[x].Name);
        ddlRoles.Items.Add(EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer.CustomerRoles[x].Name);
    }
