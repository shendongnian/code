    using DevExpress.XtraGrid.Views.Base;
    
    ColumnView View = gridControl1.MainView as ColumnView;
    View.BeginUpdate();
    try {
       int rowHandle = 0;
       DevExpress.XtraGrid.Columns.GridColumn col = View.Columns["Category"];
       while(true) {
          // locating the next row 
          rowHandle = View.LocateByValue(rowHandle, col, "SPORTS");
          // exiting the loop if no row is found 
          if (rowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
             break;
          // perform specific operations on the row found here 
          // ... 
          rowHandle++;
       }
    } finally { View.EndUpdate(); }
