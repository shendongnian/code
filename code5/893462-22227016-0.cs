    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        foreach (GridColumn column in RadGrid1.Columns)
        {
            if (column.UniqueName == "Name") //Your column uniqename
            {
                if (column.Owner.IsItemInserted)
                {
                    ((GridBoundColumn)column).ReadOnly = false;
                }
                else
                {
                    ((GridBoundColumn)column).ReadOnly = true;
                }
                break; // TODO: might not be correct. Was : Exit For
            }
        }
    
        RadGrid1.Rebind();
    }
