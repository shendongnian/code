    public static void SetDate(string keyName, string valueName, DateTime dateTime) 
    {
       Registry.SetValue(keyName,valueName, dateTime.ToBinary(), RegistryValueKind.QWord);
    }
    
    public static DateTime GetDate(string keyName, string valueName)
    {
       var result = (long)Registry.GetValue(keyName,valueName, RegistryValueKind.QWord);
       return DateTime.FromBinary(result);
    }
