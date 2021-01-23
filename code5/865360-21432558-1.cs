    public string Country
    {
        get { return country; }
        set { country = value; }
    }
    public string HomeNumber
    {
        get
        {
            if (homeNumber == null)
            {
                return string.Empty;
            }
            if (country.Equals("USA"))
            {
                return Regex.Replace(homeNumber, @"(\d{2})(\d{2})(\d{2})", "$1-$2-$3");
            }
            else if (country.Equals("Russia"))
            {
                return Regex.Replace(homeNumber, @"(\d{3})(\d{2})(\d{2})", "$1-$2-$3");
            }
        }
        set
        {
            homeNumber = value;
        }
    }
