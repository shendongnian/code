    string GetNewCountry() { return "US"; } // pass in existing Address if needed
    adr.Country = GetNewCountry();
    // or
    public void ChangeAddress(Address adr)
    {
        adr.Country = "US";
    }
