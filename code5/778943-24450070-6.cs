        // Open a database
        var dbe = new DBEngine();
        var db = dbe.OpenDatabase(@"C:\full\path\to\your\db\scratch.accdb");
        // Show database properties
        DumpProperties(db.Properties);
        // show all containers
        foreach (Container c in db.Containers)
        {
            Debug.WriteLine("{0}:{1}", c.Name, c.Owner);
            DumpProperties(c.Properties);
        }
        //Show documents and properties for a specific container
        foreach (Document d in db.Containers["Databases"].Documents)
        {
            Debug.WriteLine("--------- " + d.Name);
            DumpProperties(d.Properties);
        }
        // set a property on the Database
        Property prop = db.
            Properties["NavPane Width"];
        prop.Value = 300;
        
        // set a property on the UserDefined document
        Property userdefProp = db
            .Containers["Databases"]
            .Documents["UserDefined"]
            .Properties["ReplicateProject"];
        userdefProp.Value = true;
