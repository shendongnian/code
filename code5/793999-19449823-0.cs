    var initme = (from c in Repo.T_Users
                  orderby c.BE_Name
                  select new
                  {
                     test =  "abc",
                     col1 = c.col_1,
                     col12 = c.col_2
                     /....
                  }
                 ).FirstOrDefault();
