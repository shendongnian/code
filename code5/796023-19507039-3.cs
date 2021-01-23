    protected void ddlMachId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;    
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
    
        string val = list.SelectedValue.ToString();
        item.Cells[2].Text = val; 
    }
