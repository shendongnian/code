    private void FEAdd_Click(object sender, EventArgs e)
    {
       int n = dgvFE.Rows.Add();
       dgvFE.Rows[n].Cells[0].Value = dateTimePicker1.Value.ToString("dd-MM-yyyy");
       dgvFE.Rows[n].Cells[1].Value = MtrtextBox1.Text.ToString();
       dgvFE.Rows[n].Cells[3].Value = PltrtextBox11.Text.ToString();
       dgvFE.Rows[n].Cells[4].Value = BvtextBox12.Text.ToString();
       foreach (DataGridViewRow row in dgvFE.Rows)
       {
           row.Cells[2].Value = Math.Round((Double.Parse(row.Cells[4].Value.ToString()) / Double.Parse(row.Cells[3].Value.ToString())), 2).ToString();
           if (n > 0 && row.Index > 0)
           {
               dgvFE.Rows[row.Index-1].Cells[5].Value = Math.Round((Double.Parse(row.Cells[1].Value.ToString()) - Double.Parse(dgvFE.Rows[row.Index-1].Cells[1].Value.ToString())), 2).ToString();
           }
       }
    }
