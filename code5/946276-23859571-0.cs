    void filldistrict()
    {
        DropDownList4.Items.Clear();
        DropDownList4.Items.Add("--District--");
        String q="select * from DLIST";
        SqlCommand cmd=new SqlCommand(q,cn);
        using (SqlDataReader rec = cmd.ExectueReader())
        {
            while (rec.Read())
            {
                DropDownList4.Items.Add(new ListItem(rec.GetValue(1).ToString()));
            }
        }
    }
