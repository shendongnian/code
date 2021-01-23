    // use the DLL of the project which is currently running
    var runningAssembly = Assembly.GetExecutingAssemby();
    // all classes have a "Type" which exposes information about the class
    var organismType = typeof(Organism);
    // to keep track of all organism classes that we've found.
    var allOrganismTypes = new List<Type>();
    // go through all types in our project and locate those who inherit our 
    // organism class
    foreach (var type in runningAssembly.GetTypes())
    {
        if (organismType.IsAssignableFrom(type))
            allOrganismTypes.Add(type);
    }
    
    // Find a random index here (do it yourself)
    var theRandomIndex = 10;
    
    
    var selectedType = allOrganismTypes[theRandomIndex];
    // activator is a class in .NET which can create new objects 
    // with the help of a type
    var selected = (Organism)Activator.CreateInstance(selectedType);
