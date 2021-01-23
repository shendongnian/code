    private void button_ok_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dataGV_request.Rows.Count; i++)
        {
            DataGridViewRow row = dataGV_request.Rows[i];
            if (row.Cells[1].Value != null)
            {
                if (row.Cells[1].Value.ToString() == "ACCEPT")
                {
                    ((dynamic)System.Windows.Forms.Application.OpenForms[row.Cells[0].Value.ToString()]).accept();
                    dataGV_connected.Rows.Add(false, row.Cells[0].Value);
                    dataGV_request.Rows.Remove(row);
                    i--;
                }
                else
                {
                    ((dynamic)System.Windows.Forms.Application.OpenForms[row.Cells[0].Value.ToString()]).deny();
                    dataGV_request.Rows.Remove(row);
                    i--;
                }
            }
        }
    }
