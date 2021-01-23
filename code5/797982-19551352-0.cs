        public static string GetOSNameAndVersion()
        {
            string str = Environment.OSVersion.ToString();
            try
            {
                var obj2 = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
                            .Get()
                            .Cast<System.Management.ManagementObject>()
                            .First<System.Management.ManagementObject>();
                str = ((string)obj2["Caption"]).Trim();
                string str2 = obj2["ServicePackMajorVersion"].ToString();
                string str3 = obj2["ServicePackMinorVersion"].ToString();
                string str4 = obj2["Version"].ToString();
                if (((str2 != "") && (str2 != "0")) || ((str3 != "") && (str3 != "0")))
                {
                    str = str + " SP " + str2;
                    if ((str3 != "") && (str3 != "0"))
                    {
                        str = str + "." + str3;
                    }
                }
                if (Environment.Is64BitOperatingSystem)
                {
                    str = str + " x64";
                }
                else
                {
                    str = str + " x86";
                }
                str = str + " (" + str4 + ")";
            }
            catch
            {
                // TODO: Implement your own exception handling here
                // the way it is, the method will fall back on to the Environment.OSVersion
                //   if the query fails
            }
            if (str.StartsWith("Microsoft"))
            {
                str = str.Substring("Microsoft".Length + 1);
            }
            return str;
        }
