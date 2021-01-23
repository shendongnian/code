    public List<string> Service()
    {
        //Some code..........
        List<string> Dates = new List<string>();
        foreach (var row in d.Rows)
        {
            Dates.Add(row[0]);
        }
        return Dates;
    }
    public ActionResult GAStatistics()
    {
        return View(Service());
    }
