    var tmpCustomCount = tms.CustomAssets.Sum(a => (int?)a.Quantity);
    [Insert here:]
            SystemInformation s = new SystemInformation()
    ...
    DeleteNo = ActionCounts["delete"] == null ? 0 : ActionCounts["delete"].Single().ItemCount;
    CreateNo = ActionCounts["add"] == null ? 0 : ActionsCount["add"].Single().ItemCount;
    EditNo = ActionCounts["edit"] == null ? 0 : ActionsCount["edit"].Single().ItemCount;
