    var records
        = (from a in _context.EmploymentRecords
           join b in _context.EmploymentVerificationRecords on a.id equals b.id into bc
           where a.UserID = 1
           select new {
               a = new Record() { ID = a.id, name = a.name, IsVerification = false},
               b = bc.Select(x => new Record() { ID = x.ID, name = b.name, IsVerification = true })
           }).AsEnumerable()
             .SelectMany(x => (new [] { x.a }).Concat(x.b));
