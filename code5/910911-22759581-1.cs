    string TotalSum = "";
    var query = from r in dt.AsEnumerable()
            where r.Field<string>("Code") == strCode
            select decimal.Parse(r.Field<string>("Amount"), System.Globalization.NumberStyles.Any);
    if (query.Count() > 0)
    {
    TotalSum = string.Format("{0:C}", query.Sum());
    }
    Label1.Text = TotalSum;
