    private bool IsMatch(MemberDetail detail)
    {
        // The comparison goes here.
    }
    var list = (from data in dc.MemberDetails
        where data => this.IsMatch(data)
        select new
        {
            data.MemberID,
            data.FirstName,
            data.Surname,
            data.Street,
            data.City,
            data.County,
            data.Postcode,
            data.MembershipCategory,
            data.Paid,
            data.ToPay
        }
    ).ToList();
