    public SeenOptions SeenInformation
    {
        get
        {
            int temp = seenInformationHF.Value == "" ? 0 : Convert.ToInt32(seenInformationHF.Value);
            result = (Seen) temp;
        }
        .....
