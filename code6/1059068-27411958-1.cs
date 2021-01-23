     decimal balance = 0;  //Change for clarity
     var result = (from a in entities.Payments
                  where a.StudentID == ParamStudentID
                  select new
                  {
                     Date = a.DateAdded,
                     Code = entities.Particulars.Where(p => p.Name == a.PaymentDes).Select(sp => sp.Code).FirstOrDefault(),
                     Particulars = a.PaymentDes,
                     Debit = 0,
                     Credit = a.Amount,
                     SyTerm = a.SchoolYear + "-" + a.Term.Trim().Substring(0, 5)
                  }).ToList()
                    .Select(r=>new 
                       {
                           Rec = r, 
                           Balance = balance += r.Credit
                       });
