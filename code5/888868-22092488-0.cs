    public void show()
    {
     dt = g1.return_dt("select product1,product2,product3,product4,product5,name from tbl_products where name='Yo Yo'");
    if (dt.Rows.Count > 0)
    {
        txtname.Text = dt.Rows[0]["name"].ToString();
        txtt1.Text = dt.Rows[0]["product1"].ToString();
        //TextBox txtb;
        int x = 2;
                if (x <= 5)
                {
                    if (Counter <= 4)
                    {
                        Counter++;
                        tb.ID = "TextBox" + Counter;
                        //tb.Text = tb.ID;
                        tb = (TextBox)ctrl;
                        LiteralControl linebreak = new LiteralControl("<br />");
                        tb.Text = dt.Rows[0]["product'" + x + "'"].ToString();
                        PlaceHolder2.Controls.Add(tb);
                        PlaceHolder2.Controls.Add(linebreak);
                        ControlIdList.Add(tb.ID);
                        ViewState["ControlIdList"] = ControlIdList;
                        x++;
                    }
                    //txtb = (TextBox)ctrl;
                    //LiteralControl linebreak = new LiteralControl("<br />");
                    //txtb.Text = dt.Rows[0]["product'" + x + "'"].ToString();
                    //PlaceHolder2.Controls.Add(txtb);
                    //PlaceHolder2.Controls.Add(linebreak);
                    //x++;
                }
            }
        }
