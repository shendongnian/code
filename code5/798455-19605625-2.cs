        foreach(var table in tables)
        {
            if (table.name != "sysdiagrams")
            {
                var InterfaceT4 = new InterfaceTemplate();
                InterfaceT4.Session = new Dictionary<string, object>();
                InterfaceT4.Session.Add("tableName", table.name);
                InterfaceT4.Session.Add("manager", manager);
                InterfaceT4.InitializeSession();
                InterfaceT4.ProcessTemplate();
            }
            manager.StartNewFile(table.Name, ...);
            // generate object code
        }
        manager.Process();
    Where you create another T4 template, named "InterfaceTemplate.tt" that is a Preprocessed template. That realizes the same code as the .ttinclude file.
