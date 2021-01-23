    // TableLayoutPanel Initialization
    TableLayoutPanel panel = new TableLayoutPanel();
    panel.ColumnCount = 3;
    panel.RowCount = 1;
    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
    panel.Controls.Add(new Label() { Text = "Address" }, 1, 0);
    panel.Controls.Add(new Label() { Text = "Contact No" }, 2, 0);
    panel.Controls.Add(new Label() { Text = "Email ID" }, 3, 0);
    
    // For Add New Row (Loop this code for add multiple rows)
    panel.RowCount = panel.RowCount + 1;
    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
    panel.Controls.Add(new Label() { Text = "Street, City, State" }, 1, panel.RowCount-1);
    panel.Controls.Add(new Label() { Text = "888888888888" }, 2, panel.RowCount-1);
    panel.Controls.Add(new Label() { Text = "xxxxxxx@gmail.com" }, 3, panel.RowCount-1);
