           try
            {
                string installkey = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
                string entryLabel = "YourExe.exe";
                string develop = "YourExe.vshost.exe";//This is for Visual Studio Debugging... 
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                string version = osInfo.Version.Major.ToString() + '.' + osInfo.Version.Minor.ToString();
                uint editFlag = (uint)((version == "6.2") ? 0x2710 : 0x2328); // 6.2 = Windows 8 and therefore IE10
                Microsoft.Win32.RegistryKey existingSubKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(installkey, false); // readonly key
                if (existingSubKey.GetValue(entryLabel) == null)
                {
                    existingSubKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(installkey, true); // writable key
                    existingSubKey.SetValue(entryLabel, unchecked((int)editFlag), Microsoft.Win32.RegistryValueKind.DWord);
                }
                if (existingSubKey.GetValue(develop) == null)
                {
                    existingSubKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(installkey, true); // writable key
                    existingSubKey.SetValue(develop, unchecked((int)editFlag), Microsoft.Win32.RegistryValueKind.DWord);
                }
            }
            catch
            {
                MessageBox.Show("You Don't Have Admin Previlege to Overwrite System Settings");
            }
        }
