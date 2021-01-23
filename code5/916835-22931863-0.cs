    foreach (DataRow row in dt.Rows)
    {
         dataGridView1.Rows.Add(row);
        //string v = row["num"].ToString();
        //string v1 = row["nam"].ToString();
        //string v2 = row["amt"].ToString();
        //foreach (DataGridViewRow gridRow in dataGridView1.Rows)
        //{
            //DataGridViewCell cell1 = gridRow.Cells[0] as DataGridViewCell;
            //DataGridViewCell cell2 = gridRow.Cells[1] as DataGridViewCell;
            //DataGridViewCell cell3 = gridRow.Cells[2] as DataGridViewCell;
            //cell1.Value = v;
            //cell2.Value = v1;
            //cell3.Value = v2;
        //}
    }
