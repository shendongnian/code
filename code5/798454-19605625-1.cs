        <#@ include file="interfaces.ttinclude" #>
        foreach(var table in tables)
        {
            if (table.name != "sysdiagrams")
                Interfacegeneratora(table.Name, manager);
            
            // generate object code
            manager.StartNewFile(table.name, ...);
            // generate object code here
        }
        manager.Process();
    Where the file "interfaces.ttinclude" contains something like
        <#+ void Interfacegeneratora(string tableName, TemplateFileManager manager)
            {
                manager.StartNewFile(tableName + "mm.cs", ...);
                // generate interface code
            }
        #>
               
