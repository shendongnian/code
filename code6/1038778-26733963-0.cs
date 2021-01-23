    Type Access = Type.GetTypeFromProgID("Access.Application");
    if (Access != null)
    {
        dynamic access = Activator.CreateInstance(Access);
        string ver = access.Version;
    }
