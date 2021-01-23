    public static String GetHDDSerialNo()
    {
        ManagementClass mangnmt = new ManagementClass("Win32_DiskDrive");
        ManagementObjectCollection mcol = mangnmt.GetInstances();
        string result = "";
        foreach (ManagementObject strt in mcol)
        {
            if (Convert.ToString(strt["MediaType"]).ToUpper().Contains("FIXED"))
            {
                result += Convert.ToString(strt["SerialNumber"]);
            }
        }
        return result;
    }
