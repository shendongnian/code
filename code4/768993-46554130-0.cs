    List<dynamic> objs = new List<dynamic>();
    dynamic rec1 = new ExpandoObject();
    rec1.Id = 10;
    rec1.Name = @"Mark";
    rec1.JoinedDate = new DateTime(2001, 2, 2);
    rec1.IsActive = true;
    rec1.Salary = new ChoCurrency(100000);
    objs.Add(rec1);
    
    dynamic rec2 = new ExpandoObject();
    rec2.Id = 200;
    rec2.Name = "Tom";
    rec2.JoinedDate = new DateTime(1990, 10, 23);
    rec2.IsActive = false;
    rec2.Salary = new ChoCurrency(150000);
    objs.Add(rec2);
    
    using (var parser = new ChoCSVWriter("emp.csv").WithFirstLineHeader())
    {
        parser.Write(objs);
    }
