    using (var db = new MyDbContext())
    {
        foreach (Match match in r.Matches(input))
        {
            var list = new List<IdiomExample>();
            
            string val = match.Groups[1].Value;  // Idiom
            string val2 = match.Groups[2].Value; // Meaning
            string val3 = match.Groups[3].Value; // Desc
            foreach (Capture c in match.Groups["my"].Captures)
            {
                list.Add(new IdiomExample{Item = c.Value});
            }
            db.Idioms.Add(new Idiom
            {
                Verb = val,
                Meaning = val2,
                Description = val3,
                IdiomExamples = list
            });
        }
        db.SaveChanges();
    }
