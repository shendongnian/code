    grdExpressions.SuspendLayout();
    grdExpressions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    
    DataGridViewCheckBoxColumn enabledColumn = new DataGridViewCheckBoxColumn();
    enabledColumn.Name = "columnEnabled";
    enabledColumn.HeaderText = "EN";
    enabledColumn.FillWeight = 1;
    enabledColumn.MinimumWidth = 30;
    grdExpressions.Columns.Add(enabledColumn);
    
    grdExpressions.ResumeLayout(false);
    grdExpressions.PerformLayout();
