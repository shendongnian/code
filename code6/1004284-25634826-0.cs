          public void Test()
        {
            System.Web.UI.HtmlControls.HtmlGenericControl p = new System.Web.UI.HtmlControls.HtmlGenericControl("p");
            p.InnerHtml = @"<strong>Test</strong>";
            // ...
            ListItems.Controls.Add(p);
            Button b = new Button();
            b.ID = "cmdTest";
            b.Text = "Test";
            b.Click += new EventHandler(test_Click);
            p.Controls.Add(b);
        }
        protected void test_Click(object sender, EventArgs e)
        {
           // ListItems.InnerHtml = "Test button clicked";
            txtTestResults.Text = "Test button clicked at " + DateTime.Now.ToShortTimeString();
        }
