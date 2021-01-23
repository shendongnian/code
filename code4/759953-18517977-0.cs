    public override String MyCheckBox
    {
        get
        {
            if (!string.IsNullOrEmpty(myCheckBox))
                return myCheckBox;
            // Tried the following commented code to get value:
            // Record.MyCheckBox = myCheckBox;
            return string.Join(",", MyList.Where(x => x.Selected)
                .Select(x => x.Value).ToArray());
        }
        set
        {
            myCheckBox = value;
            // Tried the following commented code to set value:
            // Record.MyCheckBox = myCheckBox;
        }
    }
