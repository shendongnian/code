    public string Value
    {
        get
        {
            return string.Format("{0:D" + this.NumberOfZero + "}", this.value);
        }
    }
