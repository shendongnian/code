    public Dictionary<string, List<custom>> query1;
    string connstr = "Data Source=(local);Initial Catalog=t;Integrated Security=True";
        string query = "SELECT * FROM [td]";
        DataTable dTable = new DataTable();
        using (SqlConnection sqlconn = new SqlConnection(connstr))
        {
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, sqlconn);
            sqlda.Fill(dTable);
            query1 = dTable.AsEnumerable().GroupBy(x => x.Field<string>("HeaderName"))
                .ToDictionary(grp => grp.Key, x => x.Select(y => new custom()
                {
                    MetricName = y.Field<string>("MetricName/KPI"),
                    FiscalYeartarget = y.Field<double>("FiscalYeartarget").ToString(),
                    Status = y.Field<string>("Status"),
                    VTF = y.Field<double>("VTF").ToString(),
                    VTF_Percent = y.Field<double>("VTF %").ToString(),
                    YTDResults = y.Field<double>("YTDResults").ToString(),
                    YTDTarget = y.Field<double>("YTDTarget").ToString()
                }).ToList());
            Repeater1.DataSource = query1;
            Repeater1.DataBind();
            var counter = 0;
            foreach (var x in query1)
            {
                Repeater rptr = (Repeater)Repeater1.Controls[counter].FindControl("Repeater2");
                rptr.DataSource = x.Value.ToList();
                rptr.DataBind();
                counter++;
            }
        }
