         protected void Page_Load(object sender, EventArgs e)
        {
            string texthi = "3";
            // FIND THE PARENT
            Control form1 = Page.FindControl("form1");
            foreach (Panel pnl in form1.Controls.OfType<Panel>())
            {
                if (pnl.ID.ToUpper() == texthi.ToUpper().Replace(" ", ""))
                {
                    pnl.Visible = true;
                }
                else
                {
                    pnl.Visible = false;
                }
            }
        }
