    var query = from p in db.People
                from b in p.Books
                select new { p.fName, p.lName, p.Company, b.Title };
    var result = query.asEnumerable()
                      .Select(x => new 
                        {
                            Name = string.Format("{0}, {1}", x.lName, x.fName),
                            p.Company,
                            Book = b.Title
                        }
