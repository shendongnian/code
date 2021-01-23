    [DataMember(Name = "description")]
    public object description { get; set; }
    public string Description {
        get
        {
            var seperator = string.Empty; // replace with what you want
            var s = description as string;
            if (s != null)
                return s;
            var sArray = description as object[];
            if (sArray != null)
                return String.Join(seperator, sArray);
            return null;
        }
        set
        {
            description = value;
        }
    }
