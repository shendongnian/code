    var excel = new ExcelQueryFactory(excel);
    var info = excel.Worksheet("Sheet1")
                    .Select(z=> new
                         {
                          Name = row["Name"].Cast<string>(),
                          Age = row["Age"].Cast<int>(),
                         }).ToList();
