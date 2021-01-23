        private enum I_Am
        {
            OnTheServer,
            OnTheLocalPC
        }
        /// <summary>
        /// This method returns whether or not the application is being run at an appropriate location.
        /// </summary>
        /// <returns>Enum I_Am - Either: I_Am.OnTheServer OR I_Am.OnTheLocalPC</returns>
        private I_Am CheckLocation()
        {
            //decalre local vars...
            string bs = Path.DirectorySeparatorChar.ToString();
            string dbs = bs +bs;
            string dir = MyBaseDir;
            I_Am retval = I_Am.OnTheServer;
            //if run location is the UNC Share Server Path OR the Expected Local Server Path, or the Desktop or at the Root of a drive
            //consider this a server/invalid run location.
            if (dir == ServerBaseDir ||
                dir == LocalServerBaseDir ||
                dir == DesktopDir ||
                IsRootDrive(dir))
            {
                retval = I_Am.OnTheServer;
            }
            else
            {
                //if the location is a UNC path entered by the user (e.g.: "\\ServerName")
                if (dir.StartsWith(dbs))
                {
                    //extract the server name from the path
                    dir = dir.Remove(0, 2);
                    List<string> parts = dir.Split(new string[] { bs }, StringSplitOptions.None).ToList();
                    string servername = parts[0];
                    //get the list of possible IP addresses for that server
                    System.Net.IPHostEntry server = System.Net.Dns.GetHostEntry(servername);
                    //if that list of IPs contains our distribution server, consider this a server/invalid run location.
                    //else, all good/allow to run!
                    if (server.AddressList.Contains(System.Net.IPAddress.Parse(ServerIP)))
                        retval = I_Am.OnTheServer;
                    else
                        retval = I_Am.OnTheLocalPC;
                }
                else
                {
                    //if this is a local drive, it could be mapped to a share/network location which we must check)
                    
                    //get the drive info for the drive...
                    DriveInfo drive = new DriveInfo(dir[0].ToString());
                    //if it's NOT a network drive, all good/allow to run!
                    if (drive.DriveType != DriveType.Network)
                    {
                        return I_Am.OnTheLocalPC;
                    }
                    else
                    {
                        //if this is a network drive, we now have to check the UNC to IP mapping again...
                        
                        //get the UNC path from the ManagementObject...
                        ManagementObject mo = new ManagementObject();
                        mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", drive.Name));
                        dir = Convert.ToString(mo["ProviderName"]);
                        
                        //extract the server name from the path
                        dir = dir.Remove(0, 2);
                        List<string> parts = dir.Split(new string[] { bs }, StringSplitOptions.None).ToList();
                        string servername = parts[0];
                        //get the list of possible IP addresses for that server
                        System.Net.IPHostEntry server = System.Net.Dns.GetHostEntry(servername);
                        //if that list of IPs contains our distribution server, consider this a server/invalid run location.
                        //else, all good/allow to run!
                        if (server.AddressList.Contains(System.Net.IPAddress.Parse(ServerIP)))
                            retval = I_Am.OnTheServer;
                        else
                            retval = I_Am.OnTheLocalPC;
                    }
                }
            }
            return retval;
        }
