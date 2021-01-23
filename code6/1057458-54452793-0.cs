        static void Main(string[] args)
        {
            string displayName;
            List<string> gInstalledSoftware = new List<string>();
            using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                var key = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false);
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;
                    gInstalledSoftware.Add(displayName);
                }
            }
        }
