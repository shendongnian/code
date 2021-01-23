    protected void btnAssign_Click(object sender, EventArgs e)
    {
        Dictionary<int, string> selectedEmployees = new Dictionary<int, string>();
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
               CheckBox chkRow = (row.Cells[2].FindControl("CheckBox1") as CheckBox);
               if (chkRow.Checked)
                {
                    selectedEmployees.Add(int.Parse(row.Cells[0].Text), row.Cells[1].Text);
                }
            }
        }
        if (selectedEmployees.Any())
        {
            gridView2.DataSource = selectedEmployees;
            gridView2.DataBind();
        }
