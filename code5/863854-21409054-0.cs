     protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridColumn col in RadGrid1.MasterTableView.Columns)
        {
            //column you may like to excluded from the export process
            if (col.UniqueName.Contains("EditCommandColumn") ||
                col.UniqueName.Contains("attachments") ||
                col.UniqueName.Contains("Upload") || col.UniqueName.Contains("Delete_col"))
            {
                col.Display = false;
            }
            else
            {
                col.Display = true;
            }
        }
        foreach (GridFilteringItem item in RadGrid1.MasterTableView.GetItems(GridItemType.FilteringItem))
            item.Visible = false;
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.FileName = "the DesiredFileName";
        RadGrid1.MasterTableView.ExportToExcel(); //this will be exported to the folder Download
        Zip();
    }
    private void Zip()
    {
        //here your method with your preferred library to zip the file exported from the radgrid
        //save it where you need it  and delete the original excel file
    }
