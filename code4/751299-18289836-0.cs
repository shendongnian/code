       static void Main(string[] args)
        {
            var scriptText = "Get-Process | Select * -First 1";  
            //var scriptText = "Get-Process | Select Name, ID -First 1";
            PowerShell powershell = PowerShell.Create();
            powershell.Runspace = RunspaceFactory.CreateRunspace();
            powershell.Runspace.Open();
            powershell.AddScript(scriptText);
            
            Dictionary<string, object> dictprop = new Dictionary<string, object>();
            foreach (PSObject result in powershell.Invoke())
            {
                System.Console.WriteLine(result.Members.Count().ToString());
                foreach (PSMemberInfo item in result.Members)
                {
                    try
                    {
                        dictprop.Add(item.Name, item.Value);
                        Console.WriteLine("Name = {0}, Value={1}", item.Name, item.Value);
                    }
                    catch (Exception ex)
                    {
                        //Null Value invocation exception.
                    }
    
                }
            } 
            Console.Read();
        }
