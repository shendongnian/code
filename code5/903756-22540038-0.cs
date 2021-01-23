    // Using reflection.
       
    
     System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection. 
    // Displaying output. 
    foreach (System.Attribute attr in attrs)
    {
        if (attr is Author)
        {
            Author a = (Author)attr;
            System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
        }
    }
