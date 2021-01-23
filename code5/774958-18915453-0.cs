    public static Image TakeScreenSnapshot(bool activeWindowOnly)
    {
        // PrtSc = Print Screen Key
        string keys = "{PrtSc}";
        if (activeWindowOnly)
            keys = "%" + keys; // % = Alt
        SendKeys.SendWait(keys);
        return Clipboard.GetImage();
    }
