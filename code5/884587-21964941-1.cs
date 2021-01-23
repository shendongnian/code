    public List<SD> GetHistory(int ID, DateTime startDate, DateTime endDate)
    {
        var list = new List<SD>();
        var q = (from s in list
                    where s.ID == ID &&
                    s.Time >= startDate && s.Time <= endDate
                    select s).Distinct(new SD.Comparer()).ToList();
        return q;
    }
