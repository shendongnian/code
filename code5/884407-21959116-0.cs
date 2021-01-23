    rows = (from p in dt.AsEnumerable()
                select new TableProperty() {
                  name = p[0].ToString(),
                        serial = p[1].ToString(),
                        address = p[2].ToString(),
                        mobile = p[3].ToString(),
                        password = p[4].ToString()
     }).ToList<TableProperty>();
