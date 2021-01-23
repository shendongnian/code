    public static Quotes GetRandomQuotes()
    {
    HsInternetDBDataContext db = new HsInternetDBDataContext();
    
    var query = from c in db.Quotes select c;
    int count = query.Count();
    if (query.Count() > 0)
    {
        Random r = new Random();
        return new Quotes(query.ToList()[r.Next(0, count)]);
    }
    else
    {
        return new Quotes();
    }
    }
