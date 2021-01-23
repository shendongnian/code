            protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            string query = "";
            string Year = "";
            string Month = "";
            if (Request["Year"] != null) Year = Request["Year"].ToString();
            if (Request["Month"] != null) Month = Request["Month"].ToString();
            if ((Year == "") && (Month == ""))
            {
                query = "SELECT SUM(TotalRevenue) AS Total, YEAR(Date) AS Year FROM test GROUP BY YEAR(Date)";
            }
            else if (Month == "")
            {
                query = "SELECT SUM(TotalRevenue) AS Total, MONTH(Date) AS year FROM test WHERE YEAR(Date) = " + Year + "  GROUP BY MONTH(Date)";
            }
            else
            {
                query = "SELECT SUM(TotalRevenue) AS Total, DAY(Date) AS Year FROM test WHERE YEAR(Date) = " + Year + " AND MONTH(Date) = " + Month + "  GROUP BY DAY(Date)";
            }
            
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            Chart1.DataSource = cmd.ExecuteReader();
            Series Series1 = new Series();
            Series1.XValueMember = "Year";
            Series1.YValueMembers = "Total";
            Chart1.Series.Add(Series1);
            Chart1.Series[0].ChartType = SeriesChartType.Column;
            Chart1.DataBind();
            foreach (DataPoint p in Chart1.Series[0].Points)
            {
                if ((Year != "") && (Month != ""))
                {
                    p.Url = string.Format("Default.aspx");
                }
                else if (Year != "")
                {
                    p.Url = string.Format("Default.aspx?Year={0}&Month={1}", Year, p.XValue);
                }
                else
                {
                    p.Url = string.Format("Default.aspx?Year={0}", p.XValue);
                }
            }
        }
