    EntitiesModel model = new EntitiesModel();
    
    var rolls = from pay in model.Payrolls
                where pay.Cutoff == 1 && pay.PayrollMonth == "August" && pay.DateGenerated.year == 2014
                select new
                {
                     cutoff= pay.Cutoff,
                     lname = pay.Employee.LastName,    
                     fixBir= pay.Employee.Job.Rate * 25,
                     MonthsWorked_FixBIR_TODATE = (from pay2 in model.Payrolls
                                  where pay2.DateGenerated.Year == int.Parse(yearField.Text)
                                  && pay2.EmployeeId == pay.EmployeeId && pay2.Cutoff == 1
                                  select pay2).Count() * (pay.Employee.Job.Rate * 25)
                };
