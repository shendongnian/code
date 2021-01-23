    protected void Page_Load(object sender, EventArgs e)
            {
                Panel pnlMain = new Panel();
                Panel pnlContent = new Panel();
                LinkButton lbContent = new LinkButton();
                lbContent.Text = "click";
                lbContent.Click += new EventHandler(Redirect);
    
                pnlContent.Controls.Add(lbContent);
                pnlMain.Controls.Add(pnlContent);
    
                this.form1.Controls.Add(pnlMain);
    
            }
            private void Redirect(object sender, EventArgs e)
            {
    
            }
