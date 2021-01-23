    [WebMethod]
    public static CascadingDropDownNameValue[] GetSubsystems(string knowCategoryValue, string category)
    {
        // get a list of subsystems
        string url = @"http://osw-hml3mes.novelis.biz:3020/Preheat/Downtime/Subsystems";
        List<SorSubsystem> subsystems = new List<SorSubsystem>();
        subsystems = JsonConvert.DeserializeObject<List<SorSubsystem>>(new WebClient().DownloadString(url));
        // create a list of drop downs
        List<CascadingDropDownNameValue> subsystemsList = new List<CascadingDropDownNameValue>();
        foreach(SorSubsystem sub in subsystems)
        {
            subsystemsList.Add(new CascadingDropDownNameValue(sub.Description, sub.SubSystemCode));
        }
        return subsystemsList.ToArray();
    }
    [WebMethod]
    public static CascadingDropDownNameValue[] GetReasons(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> reasons = new List<CascadingDropDownNameValue>();
        string url = @"http://osw-hml3mes.novelis.biz:3020/Preheat/Downtime/Reasons";
        List<SorReason> loadReason = new List<SorReason>();
        loadReason = JsonConvert.DeserializeObject<List<SorReason>>(new WebClient().DownloadString(url));
        foreach (SorReason res in loadReason)
        {
            if(res.SubSystemCode == "A")
                reasons.Add(new CascadingDropDownNameValue(res.Description, res.SubSystemCode));
        }
        return reasons.ToArray();
    }
