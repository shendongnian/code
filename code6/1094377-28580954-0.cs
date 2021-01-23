    gridView1.Columns["fieldName"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
//
    DevExpress.XtraGrid.GridControl gridControl;
    DevExpress.XtraGrid.Views.Grid.GridView gridView;
    
    to enable grouping capability
    gridView.OptionsView.ShowGroupPanel = true
    
    to disable
    gridView.OptionsView.ShowGroupPanel = false
