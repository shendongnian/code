    public static IList<Member> GetDetails(string fullname)
    {
       IList<Member> ccc;
       using (var context = new NameDataContext(ConnectionString))
       {
          ccc = (from ee in context.Members
             where ee.FullName == fullname
             select new Member()
                  {
                  Address = ee.Address ,
                  Telephone = ee.Telephone
                  }
                 ).ToList();
       }
       return ccc;
    }
