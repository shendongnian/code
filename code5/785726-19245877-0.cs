    DevExpress.XtraPivotGrid.PivotGridControl pivotGrid = new DevExpress.XtraPivotGrid.PivotGridControl();
    
    Controls.Add(pivotGrid);
    pivotGrid.ForceInitialize();
    pivotGrid.DataSource = database.Tables[0];
    pivotGrid.RetrieveFields();
