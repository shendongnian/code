     var emp = from b in contxt.EmployeeAccesses
                  join c in contxt.View_HCM on b.EmpNo.Value equals c.EmpNo.Value
                  select new                     
                  {
                      b.EmpNo,
                      c.EmailAddress
                  };
