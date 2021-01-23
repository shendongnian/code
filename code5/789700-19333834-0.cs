        private Button btn;
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            btn = new Button();
            btn.ID = "btnClickMe";
            btn.Text = "Click me ... ";            
            btn.Click += new EventHandler(btn_Click);
            Controls.Add(btn);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToLongTimeString();
        }
