    public static List<MasterReject> GetDatas()
    {
        var context = new FingerScanContext();
        // assuming that Id is the primary key and you want to sort on that
        return context.MasterRejects.OrderBy(m=> m.Id).ToList();
    }
