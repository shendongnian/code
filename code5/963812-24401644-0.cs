        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session[((LinkButton)sender).ID + "visited"] = System.Drawing.Color.Purple;
            // your code here
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session[((LinkButton)sender).ID + "visited"] = System.Drawing.Color.Purple;
            // your code here
        }
        protected void LinkButtons_PreRender(object sender, EventArgs e)
        {
            LinkButton lnkbtn = (LinkButton)sender;
            lnkbtn.ForeColor = (System.Drawing.Color)(Session[lnkbtn.ID + "visited"] ?? System.Drawing.Color.Blue);
        }
