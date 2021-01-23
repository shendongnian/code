    using DevExpress.XtraGrid.Views.Grid;
    
    private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
       if (e.Column.FieldName == "FieldName") return;
       GridView gv = sender as GridView;
       string fieldName = gv.GetRowCellValue(e.RowHandle, gv.Columns["FieldName"]).ToString();
       switch (fieldName) {
          case "Population":
             e.RepositoryItem = repositoryItemSpinEdit1;
             break;
          case "Country":
             e.RepositoryItem = repositoryItemComboBox1;
             break;
          case "Capital":
             e.RepositoryItem = repositoryItemCheckEdit1;
             break;
       }           
    }
