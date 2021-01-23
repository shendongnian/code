     public static bool IsHostHeaderUnderUse(string ipAddress,string port, string hostname)
        {
            bool alreadyUnderUse = false;
            var header = string.Format("{0}:{1}:{2}", ipAddress, port, hostname);
            int? iisVersion = IISUtility.GetIISVersion();
            if (iisVersion.HasValue && iisVersion < 7)
            {
                DirectoryEntry iis = new DirectoryEntry("IIS://localhost/W3SVC");
                foreach (DirectoryEntry directoryEntry in iis.Children)
                {
                    var bindings = directoryEntry.Properties["ServerBindings"];
                    if (bindings.Contains(header))
                    {
                        alreadyUnderUse = true;
                        break;
                    }
                }
            }
            else
            {
                var serverManager = new ServerManager();
                foreach (Site site in serverManager.Sites)
                {
                    foreach (var binding in site.Bindings)
                    {
                        if (binding.BindingInformation.Contains(header))
                        {
                            alreadyUnderUse = true;
                            break;
                        }
                    }
                    if (alreadyUnderUse) { break; }
                }
            }
            return alreadyUnderUse;
        }
