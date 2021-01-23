        protected void Page_Load(object sender, EventArgs e)
        {
            // add comment div
            Panel pnl = new Panel();
            pnl.CssClass = "comment_body";
            form1.Controls.Add(pnl);
            // add rating div
            Panel pnlRating = new Panel();
            pnlRating.CssClass = "rating";
            pnl.Controls.Add(pnlRating);
            // button 1
            Button btn = new Button();
            btn.ID = "uniqueId";    // here you set a unique id, which you can check in button click
            btn.Text = "Click me";
            btn.Click += new EventHandler(btn_Click);
            pnlRating.Controls.Add(btn);
            //button 2
            Button btn2 = new Button();
            btn2.ID = "uniqueId2";  // here you set a unique id, which you can check in button click
            btn2.Text = "Click me";
            btn2.Click += new EventHandler(btn_Click);
            pnlRating.Controls.Add(btn2);
        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // identify the button by id
            switch (btn.ID)
            {
                case "uniqueId":
                    break;
                case "uniqueId2":
                    break;
            }
        }
