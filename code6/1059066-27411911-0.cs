    var result = (from a in entities.Payments
                 where a.StudentID == ParamStudentID
                 orderby a.DateAdded ascending
                 select new
                 {
                     Date = a.DateAdded,
                     Code = entities.Particulars.Where(p => p.Name == a.PaymentDes).Select(sp => sp.Code).FirstOrDefault(),
                     Particulars = a.PaymentDes,
                     Debit = 0,
                     Credit = a.Amount,
                     Balance = 0,
                     SyTerm = a.SchoolYear + "-" + a.Term.Trim().Substring(0, 5)
                  }).ToList();
    double balance = 0;
    foreach(var item in result)
    {
        balance += item.Credit;
        item.Balance = balance;
    }
