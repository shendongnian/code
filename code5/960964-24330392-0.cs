                string path = string.Empty;
                Process[] processlist = Process.GetProcesses();
                foreach (Process theprocess in processlist)
                {
                    if (theprocess.ProcessName == "EXCEL")
                    {
                        path = theprocess.MainModule.FileName;
                        break;
                    }
                }
                if (path == string.Empty)
                {
                    Type officeType = Type.GetTypeFromProgID("Excel.Application");
                    dynamic xlApp = Activator.CreateInstance(officeType);
                    xlApp.Visible = false;
                    path = xlApp.Path + @"\Excel.exe";
                    xlApp.Quit();
                }
