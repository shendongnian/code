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
                string spMaj = obj2["ServicePackMajorVersion"].ToString();
                string spMin = obj2["ServicePackMinorVersion"].ToString();
                string osVer = obj2["Version"].ToString();
                if (((spMaj != "") && (spMaj != "0")) || ((spMin != "") && (spMin != "0")))
                {
                    str = str + " SP " + spMaj;
                    if ((spMin != "") && (spMin != "0"))
                    {
                        str = str + "." + spMin;
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
                str = str + " (" + osVer + ")";
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
