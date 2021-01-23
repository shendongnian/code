    protected void dropdownlist_DataBound(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataView dv = (DataView)sqldatasource.Select(DataSourceSelectArguments.Empty);
            dt = dv.ToTable();
            foreach (DataRow dr in dt.Rows)
            {
                dropdownlist.Items.FindByValue(dr[0].ToString()).Attributes.Add("attr0", dr[2].ToString());
                dropdownlist.Items.FindByValue(dr[0].ToString()).Attributes.Add("attr1", dr[3].ToString());
                dropdownlist.Items.FindByValue(dr[0].ToString()).Attributes.Add("attr2", dr[4].ToString());
                
            }
        }
