    using System;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text;
    
    namespace PowershellTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                InitialSessionState initial = InitialSessionState.CreateDefault();
                String[] modules = { "DnsClient" };
                initial.ImportPSModule(modules);
                Runspace runspace = RunspaceFactory.CreateRunspace(initial);
                runspace.Open();
                RunspaceInvoke invoker = new RunspaceInvoke(runspace);
    
                Collection<PSObject> results = invoker.Invoke("Resolve-DnsName 'localhost'");
                runspace.Close();
    
                // convert the script result into a single string
    
                StringBuilder stringBuilder = new StringBuilder();
                foreach (PSObject obj in results)
                {
                    foreach (PSMemberInfo m in obj.Members)
                    {
                        stringBuilder.AppendLine(m.Name + ":");
                        stringBuilder.AppendLine(m.Value.ToString());
                    }
                }
    
                Console.WriteLine(stringBuilder.ToString());
                Console.ReadKey();
            }
        }
    }
