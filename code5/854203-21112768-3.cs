    var tmpCustomCount = tms.CustomAssets.Sum(a => (int?)a.Quantity);
    [Insert here:]
            SystemInformation s = new SystemInformation()
    ...
    DeleteNo = ActionCounts["delete"].Single().ItemCount;
    CreateNo = ActionCounts["add"].Single().ItemCount;
    EditNo = ActionCounts["edit"].Single().ItemCount;
