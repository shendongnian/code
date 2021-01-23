        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source = tc02e1p4; user id=zipcode_user; password=zipcode_!T; Initial Catalog = ZIPCodeRef"))
                {
                    conn.Open();
                    string query = " Select [Facility] from ZIPCodeReference where category = 'SNC' and ZIP='77003'";
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TableRow row = new TableRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    TableCell cell = new TableCell();
                                    var tempString = reader[i].ToString();
                                    var ColumnContentAsString = (i == (reader.FieldCount - 1)) ? tempString + "," : tempString;
                                    TextBox tb = new TextBox();
                                    tb.Width = new Unit("110%");
                                    tb.Text = ColumnContentAsString;
                                    cell.Controls.Add(tb);
                                    row.Cells.Add(cell);
                                }
                                Table1.Rows.Add(row);
                            }
                        }
                    }
                    conn.Close();
                }
            }
        }
