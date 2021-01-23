        private static List<string> getAccessTables()
        {
            List<string> tables = new List<string>() {"A", "B", "C", "D", "E", "F", "G" };
            return tables;
        }
        public static void BuildPackage(/*Microsoft.SqlServer.Dts.Tasks.ScriptTask.ScriptObjectModel Dts*/)
        {
            var tables = getAccessTables();
            var app = new Application();
            Package package = new Package();
            package.Name = "AccessToFlatFile";
            // Add the Data Flow Task 
            int cnt = 1;
            Executable tsk = null, prevTsk = null;
            for (int i = 0; i < Math.Ceiling(tables.Count * 1.0 / cnt * 1.0); i++)
            {
                if (i > 0)
                {
                    prevTsk = tsk;
                }
                tsk = package.Executables.Add("STOCK:PipelineTask");
                //tsk = package.Executables[i];
                // Get the task host wrapper, and the Data Flow task
                TaskHost taskHost = tsk as TaskHost;
                taskHost.Name = string.Format("DFT {0}", tables[i]);
                if (i > 0)
                {
                    Console.WriteLine(string.Format("Linking {0:36} to {1:36}", (tsk as TaskHost).Name, (prevTsk as TaskHost).Name));
                    //prevTsk = package.Executables[i-1];
                    PrecedenceConstraint pcPipelineTask =
                           package.PrecedenceConstraints.Add((Executable)prevTsk, (Executable)tsk);
                }
            }
            app.SaveToXml(String.Format(@"C:\Users\bfellows\documents\visual studio 2013\Projects\WTF\WTF\{0}.dtsx", package.Name + tables.Count.ToString()), package, null);
            package.Dispose();
            Console.WriteLine();
            AltBuildPackage();
        }
        public static void AltBuildPackage(/*Microsoft.SqlServer.Dts.Tasks.ScriptTask.ScriptObjectModel Dts*/)
        {
            var tables = getAccessTables();
            var app = new Application();
            Package package = new Package();
            package.Name = "AccessToFlatFile";
            // Add the Data Flow Task 
            int cnt = 1;
            Executable tsk = null, prevTsk = null;
            for (int i = 0; i < Math.Ceiling(tables.Count * 1.0 / cnt * 1.0); i++)
            {
                tsk = package.Executables.Add("STOCK:PipelineTask");
                // This line is what is causing you pain. I don't know why
                // Theory is that you're losing your reference
                Console.WriteLine(string.Format("\tHash before {0}", tsk.GetHashCode()));
                tsk = package.Executables[i];
                Console.WriteLine(string.Format("\tHash after  {0}", tsk.GetHashCode()));
                // Get the task host wrapper, and the Data Flow task
                TaskHost taskHost = tsk as TaskHost;
                taskHost.Name = string.Format("DFT {0}", tables[i]);
                // if the above tsk = assignment is delayed to this point
                // the reassignment works fine.
                tsk = package.Executables[i];
                if (i > 0)
                {                    
                    prevTsk = package.Executables[i - 1];
                    Console.WriteLine(string.Format("Linking {0:36} to {1:36}", (tsk as TaskHost).Name, (prevTsk as TaskHost).Name));
                    PrecedenceConstraint pcPipelineTask =
                           package.PrecedenceConstraints.Add((Executable)prevTsk, (Executable)tsk);
                }
            }
            app.SaveToXml(String.Format(@"C:\Users\bfellows\documents\visual studio 2013\Projects\WTF\WTF\Alt{0}.dtsx", package.Name + tables.Count.ToString()), package, null);
            package.Dispose();
        }
