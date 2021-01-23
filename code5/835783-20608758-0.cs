     protected void Button1_Click(object sender, EventArgs e)
    {
        int price;
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[4]) > Convert.ToInt32(minamount.Text))
            {
                price = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]);
                price= price*((100- Convert.ToInt32(discountrate.Text))/100);
                ds.Tables[0].Rows[i].ItemArray[4] = price;
                Gridview2.DataSource=ds;
                GridView2.DataBind();
            }
        }
    }
