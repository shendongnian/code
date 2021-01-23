    PDbContext _db = new PDbContext();
    Computer c = new Computer();
    c.ComputerName = "sdsd";
    c.UserId = null;
    _db.Computers.Add(c);
    _db.SaveChanges();
