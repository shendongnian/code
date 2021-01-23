        public string btnID="";
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0;
            
            foreach (ListItem li in ListItems)
            {
                Button b = new Button();
                
                b.Text = li.Text;
                b.PostBackUrl = "StartUpPage.aspx";
                b.ID = "ctl" + i;
                btnID = b.ID;
                PlaceHolderButtons.Controls.Add(b);
                i++;
            }
        }
