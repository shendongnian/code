    protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[9] { new DataColumn("S"), new DataColumn("Date"), new DataColumn("Type")
                    ,new DataColumn("ProductName"), new DataColumn("PartNo"), new DataColumn("OBalance"),
                    new DataColumn("Receipt"), new DataColumn("Issues"), new DataColumn("CBalance")});
                    dt.Rows.Add("1", "26/07/2013", "FTE", "P16", "01110101", "500", "0", "0", "500");
                    dt.Rows.Add("2", "24/01/2014", "EP", "P16", "01110101", "500", "0", "100", "400");
                    dt.Rows.Add("3", "19/12/2013", "FTE", "P7", "01110102", "1000", "0", "0", "1000");
                    var names = (from DataRow dr in dt.Rows
                                 select (string)dr["ProductName"]).Distinct();
                    StringBuilder s = new StringBuilder();
                    s.Append("<table>");
                    foreach (var r in names)
                    {
                        s.Append("<tr><td colspan='5'>ProductName:" + r + "</td></tr>");
                        var rows = from DataRow dr in dt.Rows
                                   where dr["ProductName"] == r
                                   orderby (string)dr["S"]
                                   select dr;
                        if (rows.Count() > 0)
                        {
                            s.Append("<tr><td>Date</td><td>Type</td><td>Receipt</td><td>Issues</td><td>Balance</td></tr>");
    
                            foreach (var r1 in rows)
                            {
                                s.Append("<tr><td>" + (string)r1["Date"] + "</td><td>" + (string)r1["Type"] + "</td><td>" + (string)r1["Receipt"] + "</td><td>" + (string)r1["Issues"] + "</td><td>" + (string)r1["CBalance"] + "</td></tr>");
                            }
                            s.Append("<tr><td colspan='5'>Closing Balance :" + (string)rows.Last()["CBalance"] + "</td></tr>");
                        }
                        s.Append("<tr><td colspan='5'></td></tr>");
                    }
                    s.Append("</table>");
                    Response.Write(s.ToString());
                }
            }
