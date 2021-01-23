    private void createControls()
        {
            PlaceHolder2.Controls.Clear();
            DataTable dt = Session["Table"] as DataTable;
            for (int i = 1; i < 5; i++)
            {
                int cnt = 0;
                cnt = i;
                TextBox tb = new TextBox();
                cnt = cnt + 1;
                tb.ID = "TextBox" + i;
                tb.Text = dt.Rows[0]["Product" + cnt + ""].ToString();
                LiteralControl linebreak = new LiteralControl("<br />");
                PlaceHolder2.Controls.Add(tb);
                PlaceHolder2.Controls.Add(linebreak);
            }
        }
        private void assignValues()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product2", typeof(string));
            dt.Columns.Add("Product3", typeof(string));
            dt.Columns.Add("Product4", typeof(string));
            dt.Columns.Add("Product5", typeof(string));
            DataRow lrow = dt.NewRow();
            lrow["Product2"] = "ABC";
            lrow["Product3"] = "DEF";
            lrow["Product4"] = "GHI";
            lrow["Product5"] = "JKL";
            dt.Rows.Add(lrow);
            Session["Table"] = dt;
        }
     protected void Button3_Click(object sender, EventArgs e)
        {
            assignValues();
            createControls();
        }
