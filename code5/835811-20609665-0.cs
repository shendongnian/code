        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                radComboBox1.Visible = false;
                radComboBox2.Visible = false;
            }
        }
