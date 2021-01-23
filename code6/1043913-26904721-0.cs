                DataTable dt = new DataTable();
                dt.Columns.Add("flag");
                dt.Columns.Add("value");
                dt.Columns.Add("dep");
                dt.Rows.Add("0", "20", "3");
                dt.Rows.Add("1", "35", "47");
                dt.Rows.Add("2", "77", "23");
                var myResults = from o in dt.AsEnumerable()
                                select new
                                {
                                    flag = o.Field<string>("flag"),
                                    value = (o.Field<string>("flag") == "1") ? string.Empty : o.Field<string>("value"),
                                    dep = (o.Field<string>("flag") == "1") ? string.Empty : o.Field<string>("dep")
                                };
