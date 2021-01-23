        foreach(var table in tables)
        {
           if (table.name != "sysdiagrams")
           {
                manager.StartNewFile(table.name+"mm.cs", ...);
                // create interface code
           }
           
           manager.StartNewFile(table.name, ...);
           // create object code
        }
        manager.Process();
