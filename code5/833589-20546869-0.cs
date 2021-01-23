    IEnumerable<Tuple<DateTime,int>> points = _db.DepartmentNumbers
        .Where(x => x.Department.Id == 1)  // LINQ to Entities WHERE
        .Select(x => new { x.Date, x.Number })  // LINQ to Entities SELECT
        .AsEnumerable()  // We want the next statement to be a select on IEnumerable instead of IQueryable.
        .Select(x => new Tuple<DateTime, int>(x.Date, x.Number)); // In-memory SELECT
