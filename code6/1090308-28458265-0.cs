    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
    panel.RowCount++;
    foreach (Control c in panel.Controls) {
      panel.SetRow(c, panel.GetRow(c) + 1);
    }
    panel.Controls.Add(new Label() { Text = text }, 0, 0);
