    public string BuyerSampleSent
    {
        get
        {
            string result= "No";
            if (this.repository.BuyerSampleSent.Equals("true",StringComparisson.OrdinalIgnoreCase)) // <-- Performance here
                result = "Yes";
            return result;
        }
        set
        {
            this.repository.BuyerSampleSent = value;
        }
    }
