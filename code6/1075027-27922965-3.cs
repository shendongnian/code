    protected void InstructionDropDown_SelectedIndexChanged(Object sender, EventArgs e)
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
