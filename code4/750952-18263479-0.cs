    public string[] AllowedRoses = new string[] {  "Red Rose", "White Rose" ,"Black Rose" };
    string _Rose = "Red Rose";
    public string Rose
    {
        get
        {
            return _Rose;
        }
        set
        {
            if (!AllowedRoses.Any(x => x == value)) 
                   throw new ArgumentException("Not valid rose");
            _Rose = value;
        }
    }
