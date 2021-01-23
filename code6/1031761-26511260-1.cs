        class Program
        {
            static void Main(string[] args)
            {
                OpenUrlInBrowser("http://www.stackoverflow.com");
            }
            public static string GetDefaultBrowserCommand()
            {
                string command = null;
                var httpKey = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command");
                if (httpKey == null)
                    throw new Exception("No default browser is configured!");
                else
                {
                    command = (string)httpKey.GetValue("", "iexplore.exe");
                    int exeIndex = command.ToLower().IndexOf(".exe");
                    if (exeIndex > -1)
                    {
                        int endOfCommand = command.IndexOf('"', exeIndex);
                        int startOfCommand = command.LastIndexOf('"', exeIndex - 1);
                        if (startOfCommand > -1 && endOfCommand > -1)
                        {
                            command = command.Substring(startOfCommand + 1, endOfCommand - 1);
                            return command;
                        }
                        else
                            throw new Exception("Error: Default browser is not set in the registry correctly!");
                    }
                    else
                        throw new Exception("The default browser registry setting does not specify an executable!");
                }
            }
            public static void OpenUrlInBrowser(string url)
            {
                string browserCommand = GetDefaultBrowserCommand();
                string launchCommand = null;
                FileInfo fi = new FileInfo(browserCommand);
                ProcessStartInfo psi = null;
                if (!fi.Exists)            
                    Console.WriteLine("The default browser specified in the registry does not physical exist on disk!");
                else
                {
                    string commandFileName = Path.GetFileNameWithoutExtension(fi.FullName).ToLower();
                    switch (commandFileName)
                    {
                        case "iexplore":
                            psi = new ProcessStartInfo(browserCommand, string.Concat("\"", url, "\"", " ", "-extoff -new"));                            
                            break;
                        default:
                            launchCommand = string.Concat(browserCommand, " ", "\"", url, "\"");
                            psi = new ProcessStartInfo(browserCommand, string.Concat("\"", url, "\""));
                            break;
                    }
                }
                psi.UseShellExecute = true; //<- have to set this to make runas work
                psi.Verb = "runas"; //<- instructs the process to runas administrator, which will give the user a UAC prompt if UAC is turned on.
                Process.Start(psi);
            }
        }
