    public string XYZ(string dobFormatted, string infodateFormatted, 
            string BSN = "", string insuranceID= "", string lastname= "",
            string postalcode = "", int Homenummer = 0, string Homenummeradd = "",
            string insuranceType = "Both")
    {
        Contract.Requires(!string.IsNullOrEmpty(dobFormatted) || insuranceType == "NONE");    
    }
