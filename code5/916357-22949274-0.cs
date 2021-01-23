    protected void cblList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<string> list1 = new List<string>();
        foreach (ListItem itemList1 in cblList1.Items)
        {
            if (itemList1 .Selected == true)
            {
                list1.Add(itemList1.Text)
            }
        }
        LoadCheckBoxListList2(list1);
    }
    
    private void LoadCheckBoxListList2(List<string> list1)
    {
        DataTable dt = new DataTable("R");
        dt.Columns.Add("Route", typeof(string));
            foreach (string li in list1)
            {
                string query = @"SELECT DISTINCT tbl_information.route AS ROUTE FROM tbl_information INNER JOIN tbl_regional ON tbl_information.region = tbl_regional.id_regional WHERE tbl_information.supervisor = '" + li + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                bool b = false;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (!b)
                    {
                        dt.Rows.Add(item[0] + " (" + li + ")");
                        b = true;
                        continue;
                    }
                    dt.Rows.Add(item.ItemArray);
                }
            }
            cblRutas.DataSource = dt;
            cblRutas.DataValueField = "ROUTE";
            cblRutas.DataBind();
        }
