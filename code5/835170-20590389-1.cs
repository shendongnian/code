    public List<string> GetTutoringSubjectsLetters()
    {
        using (JewroOnlineDataContext dc = conn.GetContext())
        {
            return dc.SchoolSubjects.Select(s => s.SubjectName.Substring(0, 1)).Distinct().ToList();
        }
    }
