        public class IisManager
        {
            public static int IisVersion
            {
                get
                {
                    int iisVersion;
    
                    using (RegistryKey iisKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp"))
                    {
                        if (iisKey == null)
                            throw new Exception("IIS is not installed.");
                        iisVersion = (int)iisKey.GetValue("MajorVersion");
                    }
    
                    return iisVersion;
                }
    
            }
    
            public static IList<IisWebSite> GetIisSites()
            {
                List<IisWebSite> sites = new List<IisWebSite>();
    
                using (DirectoryEntry iisRoot = new DirectoryEntry("IIS://localhost/W3SVC"))
                {
                    iisRoot.RefreshCache();
                    sites.AddRange(iisRoot.Children.Cast<DirectoryEntry>().Where(w => w.SchemaClassName.ToLower(CultureInfo.InvariantCulture) == "iiswebserver").Select(w => new IisWebSite(w.Name, w.Properties["ServerComment"].Value.ToString())));
                }
    
                return sites;
            }
    
            public static IList<string> GetIisAppPools()
            {
                List<string> pools = new List<string>();
                using (DirectoryEntry poolRoot = new DirectoryEntry("IIS://localhost/W3SVC/AppPools"))
                {
                    poolRoot.RefreshCache(); pools.AddRange(poolRoot.Children.Cast<DirectoryEntry>().Select(p => p.Name));
                }
                return pools;
            }
    
        }
