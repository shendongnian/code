    public enum CaseOriginCode
        {
            Web = 0,
            Email = 1,
            Telefoon = 2
        }
    
    public void setCaseOriginCode(string CaseOriginCode)
    {
        int caseOriginCode = (int)(CaseOriginCode)Enum.Parse(typeof(CaseOriginCode), CaseOriginCode);
    }
