    private static Task<Tuple<DTGenericCode[], DTGenericCode[]>> GetCaseStatusAsync(
        int CaseOID, int ClientOID)
    {
        return Task.Factory.FromAsync(
            BeginGetCaseStatus, ar =>
            {
                DTGenericCode[] basicStatus;
                DTGenericCode[] arStatus;
                EndGetCaseStatus(ar, out basicStatus, out arStatus);
                return Tuple.Create(basicStatus, arStatus);
            },
            CaseOID, ClientOID, null);
    }
