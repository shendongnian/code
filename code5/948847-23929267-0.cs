    var groupedData = from r in loans.AsEnumerable()                     
                      group r by new { 
                          LoanCode = r.Field<int>("loan_code"),
                          EmpNum = r.Field<int>("emp_num") 
                      } into g
                      select new {
                          g.Key.LoanCode,
                          g.Key.EmpNum,
                          Tot = g.Sum(r => r.Field<int>("Tot")) // assume integer
                      };
