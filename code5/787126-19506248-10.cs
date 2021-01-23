    public List<AtsPlatform> GetAtsPlatformByName(string atsPlatformName)
        {
            List<AtsPlatform> atsPlatforms = null;
            string stm = String.Format("SELECT RequestNumber, NumberOfFail, NumberOfTestCase, NumberOfFailWithCR FROM {0}", atsPlatformName);
    
            atsPlatforms = new List<AtsPlatform>();
            foreach (AtsPlatform ats in ctx.ExecuteStoreQuery<AtsPlatform>(stm))
                {
                    atsPlatforms.Add(ats);
                }
    
            return atsPlatforms;
        }
