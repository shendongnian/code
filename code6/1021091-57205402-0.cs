        DataTable data = GetData();
        var groupedData = data.AsEnumerable()
            .GroupBy(d => new
            {
                Author = d["Author"]
            })
            .Select(grp => new
            {
                grp.Key,
                Books = grp.Select(row => new
                {
                    Book = row["ID"],
                    PublishDate = row["Name"],
                    Pages = row["Pages"]
                })
            });
        RepeaterOuter.DataSource = groupedData;
        RepeaterOuter.DataBind();
