     private static SomeType GetComponent(string hwclass, string syntax)
        {
            var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (var mj in mos.Get())
            {
                Convert.ToString(mj[syntax]);
            }
           return whatUNeed
        } 
