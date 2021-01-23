        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (LinkButton lb in testControl.Controls)
            {
                if (lb.ID == "LinkButton1")
                lb.Click += lb_Click;
            }
        }
        private void lb_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.microsoft.com");
        }
