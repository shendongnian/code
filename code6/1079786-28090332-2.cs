    DataGridView dgv = new DataGridView();
    dgv.Columns.Add("Header","Header");
    dgv.Columns.Add("Details", "Details");
    dgv.Dock = DockStyle.Fill;
    dgv.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    dgv.Rows.Add(new string[] { "Drew", "Some details" + Environment.NewLine + "use two lines" });
    dgv.Rows.Add(new string[] { "Bill", "More details" });
    Controls.Add(dgv);
