    public void ListPrinters()
    {
        string query = "SELECT * from Win32_Printer";
        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
        ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
    
        foreach (ManagementObject printer in managementObjectCollection)
        {
            Console.WriteLine(String.Format("Printer Name: {0}", printer.Properties["DeviceID"].Value));
            Console.WriteLine(String.Format("Attributes: {0}", Decode((UInt32)printer.Properties["Attributes"].Value)));
        }
        Console.ReadLine();
    }
    
    private static Dictionary<UInt32, string> decodeDictionary = new Dictionary<uint, string>();
    
    private static Dictionary<UInt32, string> DecodeDictionary
    {
        get
        {
            if (decodeDictionary.Keys.Count == 0)
            {
                decodeDictionary.Add(1, "PRINTER_ATTRIBUTE_QUEUED");
                decodeDictionary.Add(2, "PRINTER_ATTRIBUTE_DIRECT");
                decodeDictionary.Add(4, "PRINTER_ATTRIBUTE_DEFAULT");
                decodeDictionary.Add(8, "PRINTER_ATTRIBUTE_SHARED");
                decodeDictionary.Add(16, "PRINTER_ATTRIBUTE_NETWORK");
                decodeDictionary.Add(32, "PRINTER_ATTRIBUTE_HIDDEN");
                decodeDictionary.Add(64, "PRINTER_ATTRIBUTE_LOCAL");
                decodeDictionary.Add(128, "PRINTER_ATTRIBUTE_ENABLEDEVQ");
                decodeDictionary.Add(256, "PRINTER_ATTRIBUTE_KEEPPRINTEDJOBS");
                decodeDictionary.Add(512, "PRINTER_ATTRIBUTE_DO_COMPLETE_FIRST");
                decodeDictionary.Add(1024, "PRINTER_ATTRIBUTE_WORK_OFFLINE");
                decodeDictionary.Add(2048, "PRINTER_ATTRIBUTE_WORK_OFFLINE");
                decodeDictionary.Add(4096, "PRINTER_ATTRIBUTE_RAW_ONLY");
                decodeDictionary.Add(8192, "PRINTER_ATTRIBUTE_PUBLISHED");
                decodeDictionary.Add(16384, "PRINTER_ATTRIBUTE_FAX");
            }
    
            return decodeDictionary;
        }
    }
    
    private static string Decode(UInt32 value)
    {
        List<string> attributes = new List<string>();
    
        foreach (UInt32 key in DecodeDictionary.Keys)
        {
            if ((value & key) == key)
            {
                attributes.Add(DecodeDictionary[key]);
            }
        }
    
        return String.Join(", ", attributes.ToArray());
    }
