    public List<string> GetTutoringSubjectsLetters()
    {
       List<string> result = new List<string>(); 
        using (JewroOnlineDataContext dc = conn.GetContext())
        {
            var subjects = (from s in dc.SchoolSubjects
                            select  s.SubjectName.Substring(0,1)).Distinct();
            return subjects;
        }
    }
