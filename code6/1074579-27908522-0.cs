    protected void Page_Load(object sender, EventArgs e)
    {
        _connection = DataAccess.SelfRef().GetConnection();
        if ( !Page.IsPostBack ) 
        {
            var list = InstructionDropDown.SelectedValue;
            switch (list)
            {
            case "Form Section":
                FormSectionListBox.DataSourceID = "FormSectionDataSource";
                FormSectionListView.DataBind();
               RenderView(FormSectionListView, "hidden"); // hide listview on page load
                break;
            }
        }
    }
