    Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
    
                string packagePath = "Path of your SSIS package";
    
                Package package = app.LoadPackage(packagePath, null);
               
                //Assign your variables here.
                Variables vars = package.Variables;
                vars["FileName"].Value = variables.FileName;
                
    
    
                Microsoft.SqlServer.Dts.Runtime.DTSExecResult results = package.Execute();
    
                if (results == DTSExecResult.Success)
                {
                   //Do what u want after success.
                }
