        private string getUserDisplayName()
        {
            var username = new StringBuilder(1024);
            uint userNameSize = (uint)username.Capacity;
            // try to get display name and convert from "Last, First" to "First Last" if necessary
            if (0 != GetUserNameEx(3, username, ref userNameSize))
                return Regex.Replace(username.ToString(), @"(\S+), (\S+)", "$2 $1");
            // get SAM compatible name <server/machine>\\<username>
            if (0 != GetUserNameEx(2, username, ref userNameSize))
            {
                IntPtr bufPtr;
                try
                {
                    string domain = Regex.Replace(username.ToString(), @"(.+)\\.+", @"$1");
                    DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, domain);
                    DomainController dc = DomainController.FindOne(context);
                    if (0 == NetUserGetInfo(dc.IPAddress,
                                            Regex.Replace(username.ToString(), @".+\\(.+)", "$1"),
                                            10, out bufPtr))
                    {
                        var userInfo = (USER_INFO_10)Marshal.PtrToStructure(bufPtr, typeof(USER_INFO_10));
                        return Regex.Replace(userInfo.usri10_full_name, @"(\S+), (\S+)", "$2 $1");
                    }
                }
                finally
                {
                    NetApiBufferFree(out bufPtr);
                }
            }
            return String.Empty;
        }
