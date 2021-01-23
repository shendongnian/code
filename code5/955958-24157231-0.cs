            RegistrySecurity rs = new RegistrySecurity();
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ASUS", true);
            rs.AddAccessRule(new RegistryAccessRule("Everyone", RegistryRights.WriteKey |  RegistryRights.ReadKey, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny)); 
            if(rk != null)
            {
              rk.SetAccessControl(rs);
            }
