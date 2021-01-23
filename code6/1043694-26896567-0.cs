            string path = string.Empty;
            const string hfss_key_name = @"SOFTWARE\Ansoft\HFSS\2014.0\Desktop";
            const string hfss_value = "LibraryDirectory";
            MessageBox.Show("Getting Registry Key");
            try
            {
                RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                localKey = localKey.OpenSubKey(hfss_key_name);
                if (localKey != null)
                {
                    path = localKey.GetValue(hfss_value).ToString();
                    path += @"\HFSS\userlib\";
                }
            }
            catch (SecurityException secex)
            {
                MessageBox.Show("SecurityException: " + secex);
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show("UnauthorizedAccessException: " + uex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
