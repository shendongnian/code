    protected void fillRepeater_onitembound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            sql = "select Description,AttendanceCode from tblattendancecodes";
            ds = obj.openDataset(sql);
            ListItem li;
            RadioButtonList rbtl = (RadioButtonList)e.Item.FindControl("radioatt");
            if (rbtl != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    li = new ListItem();
                    li.Text = dt.Rows[i]["ApplicationName"].ToString();
                    li.Value = dt.Rows[i]["BuildNumber"].ToString();
                    rbtl.Items.Add(li);
                }
            }
        }
    }
