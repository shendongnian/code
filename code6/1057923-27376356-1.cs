    public IList<tblcourse> GetData()
    {
        using (var testContext = new testEntities1())
        {
            var results =
                testContext.tblcourses
                    .Select(c => new tblcourse() { C_Id = c.C_Id, C_Name = c.C_Name })
                    .ToList();
            return results;
        }
    }
