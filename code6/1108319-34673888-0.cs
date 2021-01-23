    public static List<MasterReject> GetDatas()
    {
        var context = new FingerScanContext();
    
        return context.MasterRejects.OrderBy(m=>Regex.Split(m.Replace("
        ", ""), "([0-9]+)")
       ).ToList();
    }
