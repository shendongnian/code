    dgv.AutoGenerateColumns = false;
    dgv.RowHeadersVisible = false;
    dgv.MultiSelect = false;
    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    dgv.Columns.Add(new DataGridViewTextBoxColumn() {
      HeaderText = "Share Name",
      ReadOnly = true,
      AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
      FillWeight = 25
    });
    dgv.Columns.Add(new DataGridViewTextBoxColumn() {
      HeaderText = "Path",
      ReadOnly = true,
      AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
      FillWeight = 75
    });
    var shares = new ManagementObjectSearcher("Select * from Win32_Share");
    foreach (ManagementObject share in shares.Get()) {
      dgv.Rows.Add(new String[] { share["Name"].ToString(),
                                  share["Path"].ToString() + "\n" + "AAAA" });
    }
