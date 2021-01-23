    public bool CanClickButton
    {
        get
        {
            return !String.IsNullOrWhiteSpace(firstString)
                && !String.IsNullOrWhiteSpace(secondString);
        }
    }
