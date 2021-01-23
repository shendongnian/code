        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var fieldSelectedName = hdnSelectedField.Value;
                if(!String.IsNullOrEmpty(fieldSelectedName))
                    Page.FindControl(fieldSelectedName).Focus();
            }
        }
