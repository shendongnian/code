    public string AddressInputFormatted
    {
        get
        {
            return string.Format("{0}\\n{1}, {2} {3}", Address, City, State, Zip);
        }
    }
