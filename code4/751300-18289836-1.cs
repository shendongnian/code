     static void Main(string[] args)
        {
            //var scriptText = "Get-Process | Select *";
            //var scriptText = "Get-Service";
            var scriptText = "Get-Service | Select ServiceName, Status";
            PowerShell powershell = PowerShell.Create();
            powershell.Runspace = RunspaceFactory.CreateRunspace();
            powershell.Runspace.Open();
            powershell.AddScript(scriptText);
            Dictionary<string, object> dictprop = new Dictionary<string, object>();
            foreach (PSMemberInfo item in powershell.Invoke().First().Members)
            {
                try
                {
                    dictprop.Add(item.Name, item.Value);
                    Console.WriteLine("Name = {0}, Value = {1}", item.Name, item.Value);
                }
                catch (Exception ex)
                {
                    //Null Value invocation exception.
                }
            }
            Console.Read();
        }
