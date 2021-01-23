    public static List<ListItem> GetMyCompassTUTListContent(
        List<int> ContentID, Int32 CountryID)
    {
        //Note this is IEnumerable, not IQueryable, this is important.
        IEnumerable<string> query;
        using (DbDataContext objContext = new DbDataContext())
        {
            if (CountryID == (int)MyCompassBLL.Constants.Country.Australia)
            {
                query = objContext.Contents.Where(x => ContentID.Contains(x.ID))
                    .Select(x => x.Text);
            }
            else
            {
                query = objContext.ContentCountries
                    .Where(x => ContentID.Contains(x.ContentID)
                        && x.CountryID == CountryID)
                    .Select(x => x.Text);
            }
            return query.Select((text, index) => new ListItem
            {
                Text = text,
                Value = (index + 1).ToString(),
            })
            .ToList();
        }
    }
