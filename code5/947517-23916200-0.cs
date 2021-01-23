        var assembly = AppDomain.CurrentDomain.GetAssembliesFromApplicationBaseDirectory(
                x => x.GetName().Name == "XXXX").Single();
        var controllerTypes = assembly.GetTypes().Where(x => x.Name == Model.Controller + "Controller");
        var controllerType = controllerTypes.Where(x => x.Namespace.Contains(Model.Area)).Single();
        var action = controllerType.GetMethod(Model.Action);
        var parameters = action.GetParameters();
