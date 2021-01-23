    protected void Page_Load( object sender, EventArgs e )
    {
        ddl_CloseTask.Attributes.Add("onchange", "return validate(this);");
    }
    protected void CheckDropDownSelection(object sender, EventArgs e)
    {
        if (ddl_CloseTask.SelectedValue == "YES")
        {
            CloseTask();
        }
        else
        {
            // do stuff
        }
    }
    private void CloseTask()
    {
        // do stuff
    }
