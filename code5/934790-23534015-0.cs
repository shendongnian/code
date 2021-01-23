    protected void ExpExcel_Click(object sender, EventArgs e)
    {
        foreach (GridColumn col in RadGrid1.MasterTableView.Columns)
        {
    //here is where the columns get hidden
            if (col.UniqueName.Contains("notes") || (col.UniqueName.Contains("EditCommandColumn")) ||
                (col.UniqueName.Contains("column1")))
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
        RadGrid1.ExportSettings.FileName = "OffersData_"+DatetimeHelper.CETDateTimeNow();
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
        RadGrid1.MasterTableView.Columns.FindByUniqueName("chancesy").HeaderText = "Chances y [%]";
        RadGrid1.MasterTableView.Columns.FindByUniqueName("chancesx").HeaderText = "Chances x [%]";
        RadGrid1.MasterTableView.Columns.FindByUniqueName("valuey").HeaderText = "Value z [€]";
        RadGrid1.MasterTableView.Columns.FindByUniqueName("valuex").HeaderText = "Value z [€]";
        RadGrid1.MasterTableView.Columns.FindByUniqueName("marginy").HeaderText = "Margins y [%]";
        RadGrid1.MasterTableView.Columns.FindByUniqueName("marginx").HeaderText = "Margins x [%]";
       
        RadGrid1.MasterTableView.ExportToExcel();
        
    }
