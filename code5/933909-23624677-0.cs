    GridViewTextBoxColumn newColumn;
    newColumn = new GridViewTextBoxColumn();
    newColumn.FieldName = "customer";
    newColumn.Name = "customer";
    newColumn.HeaderText = "Customer";
    newColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
    newColumn.Width = 100;
    this.MainFormGridView.Columns.Add(newColumn);
