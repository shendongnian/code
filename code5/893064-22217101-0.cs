    void loadGrid()
    {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("TNS_Date");
            DataRow dRow;
            clmDate.DataPropertyName = "TNS_Date";
            dRow= dtData.NewRow();
            dRow["TNS_Date"] = "20-01-2014";
            dtData.Rows.Add(dRow);
            dRow = dtData.NewRow();
            dRow["TNS_Date"] = "20-02-2014";
            dtData.Rows.Add(dRow);
            dRow = dtData.NewRow();
            dRow["TNS_Date"] = "20-03-2014";
            dtData.Rows.Add(dRow);
            dgvGrid.DataSource = dtData;
            for (int i = 0; i <= dgvGrid.RowCount - 1; ++i)
            {
                //Finding the right cell to change colour.
                if(DateTime.Parse(dgvGrid["TNS_Date", i].Value.ToString()) >= DateTime.Now.Date)
                dgvGrid[0, i].Style.BackColor = Color.Bisque;
            }
}
