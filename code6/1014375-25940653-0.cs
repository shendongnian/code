    private void btnChk(object sender, EventArgs e)
    {
        for (int i = 0; i < dgv.Rows.Count; i++)
        {
            if (dgv.Rows[i].Cells[1].Value.ToString()==txtName.Text)
            {
               dgv.Rows[i].Cells[1].Selected = true;
            }
        }
    }   
