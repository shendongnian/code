    // play hunt the interface
    if(viewable == null) {
        foreach(Type iType in node.GetType().GetInterfaces()) {
            if(iType.Name == "IViewable") {
                Console.WriteLine("{0} vs {1}",
                    iType.AssemblyQualifiedName,
                    typeof(IViewable).AssemblyQualifiedName);
            }
        }
    }
