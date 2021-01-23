    AgeList.AddRange(AgeListQry.Select(bd => CalculateAge(bd)).Distinct());
    //...
    private string CalculateAge(DateTime birthday)
    {
       return ((int)(DateTime.Now - bd).TotalDays / 365).ToString();
    }
