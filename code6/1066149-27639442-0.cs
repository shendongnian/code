    protected void Page_Load(object sender, EventArgs e)
        {
            Button aa = new Button();
            UpdatePanel1.ContentTemplateContainer.Controls.Add(aa);
            Panel2.Controls.Add(aa);
            aa.Click += new System.EventHandler(this.Button1_Click);
            if(Convert.ToString(ViewState["AddTwoButton"]) == "1")
                CreateSecoundButton();
        }
        private void CreateSecoundButton()
        {
            Button bb = new Button();
            UpdatePanel1.ContentTemplateContainer.Controls.Add(bb);
            Panel2.Controls.Add(bb);
            bb.Click += new System.EventHandler(this.Button2_Click);
            int i = 0;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            CreateSecoundButton();
            ViewState["AddTwoButton"] = "1";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int i = 0;
        }
