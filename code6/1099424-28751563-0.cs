    foreach(var type in assembly.GetTypes())
    {
         //if the type implements IPerson, create it:
         if(typeof(type).GetInterfaces().Contains(typeof(IPerson))
         {
             var person = (IPerson)activator.CreateInstance(type);
             
             //now you can invoke IPerson methods on person
         }
    }
