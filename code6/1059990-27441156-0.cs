    var acquisitions = from ac in db.Acquisitions
                       order by ac.Chance 
                       select ac;
    foreach (var a in acquisitions)
    {
        chances.Add(a.Chance.ToString());
        sums.Add(a.Sum.ToString());
    }
