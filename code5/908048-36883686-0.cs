    int selectedRowIntex = Globals.ThisAddIn.Application.Selection.Range.Cells[1].RowIndex;
    int selectedColumnIntex = Globals.ThisAddIn.Application.Selection.Range.Cells[1].ColumnIndex;
    
    //to get the index of the selected Table, you could use thie titel-property, if you set it before
    string selectedTableTitle = Globals.ThisAddIn.Application.Selection.Tables[1].Title;
