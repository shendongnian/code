    var names = data.GroupBy(a => a.FirstName);//get names
            var fn = data.GroupBy(a => a.FundNumber);//get the FundNumbers
            DataTable tbl = new DataTable();
            tbl.Columns.Add("LastName", typeof(string));
            tbl.Columns.Add("FirstName", typeof(string));
            tbl.Columns.Add("AnnualRate", typeof(string));
            foreach (var item in fn)
            {
                tbl.Columns.Add(item.Key, typeof(string));
            }
