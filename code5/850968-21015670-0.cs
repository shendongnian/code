    long StopBytes = 0;
    
    // Declare your dictionnary
    Dictionary<string, int> myDictionary;
    
    // Get total memory before create your dictionnary
    long StartBytes = System.GC.GetTotalMemory(true);
    
    // Initialize your dictionnary
    myDictionary = new Dictionary<string, int>();
    
    // Get total memory after create your dictionnary
    StopBytes = System.GC.GetTotalMemory(true);
    
    // This ensure a reference to object keeps object in memory
    GC.KeepAlive(myFoo); 
    
    // Calcul the difference , and that all :-)
    MessageBox.Show("Size is " + ((long)(StopBytes - StartBytes)).ToString());
