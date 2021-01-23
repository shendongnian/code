    string localized = LocalizedString(test.AudioTitle); // this gets the localized result
    public enum test // This is your enum
    {
        CreatedOn,
        Something,
        SomethingElse
    }
    public string LocalizedString(test str)  // this method will return the localized value
    {
        switch (str)
        {
            case test.AudioTitle:
                return Resources.Audio.AudioTitle; // Audio is a resource file
            case test.AudioUrl:
                return Resources.Audio.AudioUrl;
            case test.LinkTO:
                return Resources.Audio.LinkTo;
            default:
                return "";
        }
    }
