    public IEnumerable<string> GetTutoringSubjectsLetters()
    {
        using (JewroOnlineDataContext dc = conn.GetContext())
        {
            return (from s in dc.SchoolSubjects
                    select s.Remove(1))
                   .Distinct();
        }
    }
