    var xml = new XElement("companies",
                 from e in db.Employees // use your DbSet name here
                 group e by new { e.Companyid, e.Deptid, e.Location } into g
                 select new XElement("company",
                     new XAttribute("companyid", g.Key.Companyid),
                     new XAttribute("DeptID", g.Key.Deptid),
                     new XAttribute("Location", g.Key.Location),
                     from x in g
                     select new XElement("Employee",
                               new XAttribute("id", x.Employeeid),
                               new XAttribute("Employeename", x.Employeename),
                               new XAttribute("Employeeage", x.Employeeage))
                 ));
