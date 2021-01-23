    public List<tblcourse> GetData(string value)
    {
        return (from g in new testEntities1().tblcourses
                 select new tblcourse { C_Id = g.C_Id, C_Name = g.C_Name }).ToList();
    }
