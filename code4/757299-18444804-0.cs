    var tempA = new A { UID = 1, B = new List<B>() }
    tempA.B.Add(new B { UID = 2 });
    using (var dbContext = new MyContext())
    {
        dbContext.A.Attach(tempA);
        tempA.B.Clear();
        dbContext.SaveChanges();
    }
