    foreach (var controlType in System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "MyProject.MyControlNamespace")) {
        var constructor = controlType.GetConstructor(Type.EmptyTypes);
        if(constructor != null) {
            var control = constructor.Invoke(null);
            //add control to your tabControl here
        }                
    }
