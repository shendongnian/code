    void Main()
    {
        Claims.AsEnumerable().Select((claim, no) => Populate(claim, no)).ToList().ForEach(Modify);
    }
    
    public Func<Claim, int, string> Populate = (claim, no) =>
    {
        return "#" + no.ToString() + " " + claim.Applicant.FirstName + " " + claim.Applicant.LastName;
    };
    
    public Action<string> Modify = p =>
    {
        (p = p + "!!!").Dump();
    };
