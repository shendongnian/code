    ToolStripComboBox objectDropDown = new ToolStripComboBox();
    foreach (Control item in propertyGrid1.Controls)
    {
        ToolStrip toolstrip = item as ToolStrip;
        if (toolstrip != null)
        {
            toolstrip.Items.Add(objectDropDown);
        }
    }
