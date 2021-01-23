            List<Record> list = new List<Record>();
            list.Add(new Record("ABC", 2014, "Jan", 1));
            list.Add(new Record("ABC", 2014, "Jan", 2));
            list.Add(new Record("ABC", 2014, "Jan", 3));
            list.Add(new Record("ABC", 2014, "Feb", 1));
            list.Add(new Record("ABC", 2014, "Feb", 2));
            list.Add(new Record("ABC", 2014, "Mar", 1));
            list.Add(new Record("ABC", 2014, "Mar", 2));
            list.Add(new Record("ABC", 2014, "Mar", 3));
            list.Add(new Record("ABC", 2014, "Apr", 1));
            list.Add(new Record("ABC", 2015, "Jan", 1));
            list.Add(new Record("ABC", 2015, "Jan", 2));
            list.Add(new Record("ABC", 2015, "Feb", 1));
            list.Add(new Record("ABC", 2015, "Mar", 1));
            list.Add(new Record("ABC", 2015, "Apr", 1));
            var result =  from record in list
                          group record by new { record.Company, record.Year, record.Month } into g
                             select new {
                                 g.Key.Company,
                                 g.Key.Year,
                                 g.Key.Month,
                                 Version = g.Count()};
