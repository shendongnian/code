        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var fieldSelectedName = hdnSelectedField.Value;
                Page.FindControl(fieldSelectedName).Focus();
            }
        }
