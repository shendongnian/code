        Panel pnlMain = new Panel();
        Panel pnlContent = new Panel();
        LinkButton lbContent = new LinkButton();
        lbContent.Click += new EventHandler(Redirect);
        Redirect(this, EventArgs.Empty);
        
        private void Redirect(object sender, EventArgs e)
        {
        }
