    string localized = LocalizedString(test.AudioTitle);
    public enum test // This is your enum
    {
        AudioTitle,
        AudioUrl,
        LinkTO
    }
    public string LocalizedString(test str)  // this method will return the localized value
    {
        switch (str)
        {
            case test.AudioTitle:
                return Resources.Audio.AudioTitle;
            case test.AudioUrl:
                return Resources.Audio.AudioUrl;
            case test.LinkTO:
                return Resources.Audio.LinkTo;
            default:
                return "";
        }
    }
