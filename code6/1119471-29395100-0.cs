    public static class ProcessHelper
    {
        const string RegistrySubKeyName =
            @"Software\Microsoft\Windows\CurrentVersion\Run";
        public static void LaunchStartupPrograms()
        {
            foreach (string commandLine in GetStartupProgramCommandLines())
            {
                string fileName;
                string arguments;
                if (File.Exists(commandLine))
                {
                    fileName = commandLine;
                    arguments = String.Empty;
                }
                else if (commandLine.StartsWith("\""))
                {
                    int secondQuoteIndex = commandLine.IndexOf("\"", 1);
                    fileName = commandLine.Substring(1, secondQuoteIndex - 1);
                    if (commandLine.EndsWith("\""))
                    {
                        arguments = String.Empty;
                    }
                    else
                    {
                        arguments = commandLine.Substring(secondQuoteIndex + 2);
                    }
                }
                else
                {
                    int firstSpaceIndex = commandLine.IndexOf(' ');
                    if (firstSpaceIndex == -1)
                    {
                        fileName = commandLine;
                        arguments = String.Empty;
                    }
                    else
                    {
                        fileName = commandLine.Substring(0, firstSpaceIndex);
                        arguments = commandLine.Substring(firstSpaceIndex + 1);
                    }
                }
                Process.Start(fileName, arguments);
            }
        }
        static IEnumerable<string> GetStartupProgramCommandLines()
        {
            using (RegistryKey key =
                Registry.CurrentUser.OpenSubKey(RegistrySubKeyName))
            {
                foreach (string name in key.GetValueNames())
                {
                    string commandLine = (string) key.GetValue(name);
                    yield return commandLine;
                }
            }
            using (RegistryKey key =
                Registry.LocalMachine.OpenSubKey(RegistrySubKeyName))
            {
                foreach (string name in key.GetValueNames())
                {
                    string commandLine = (string) key.GetValue(name);
                    yield return commandLine;
                }
            }
        }
    }
