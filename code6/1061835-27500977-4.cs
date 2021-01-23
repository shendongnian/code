        DateTime A = DateTime.Parse("1900-01-01 01:00:00");
        DateTime B = DateTime.Parse("1900-01-01 05:00:00");
        int amountOfHours = 2;
    public bool IsWithinResidencyRange(DateTime a, DateTime b, double c)
    {
    if ((b - a).TotalHours >= c 
    && (a.TimeOfDay.Hours <= this.B.TimeOfDay.Hours - c 
    ||  b.TimeOfDay.Hours >= this.A.TimeOfDay.Hours + c))
    {
    return true;
    }
    //else
    return false;
    }
