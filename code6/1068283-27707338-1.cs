    public static void SaveLaterMessages(MSG msg)
    {
        var dic = Globals.DIC_PROFILEID__MSGS;
        List<MSG> existingLst = dic.GetOrAdd(msg.To, () => new List<MSG>());
        
        lock(existingLst)
        {
            existingLst.Add(msg);
        }
    }
