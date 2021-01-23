    //After Done Binding DataGridView Data
    foreach(DataGridViewRow DGVR in DGV_DETAILED_DEF.Rows)
    {
    	if(DGVR.Index != -1)
    	{
    		if(DGVR.Cells[0].Value.ToString() == "البدلات")
    		{
    			CurrRType = "البدلات";
    			DataGridViewCellStyle CS = DGVR.DefaultCellStyle;
    			CS.BackColor = Color.FromArgb(0,175,100);
    			CS.ForeColor = Color.FromArgb(0,32,15);
    
    			CS.Font = new Font("Times New Roman",12,FontStyle.Bold);
    			CS.SelectionBackColor = Color.FromArgb(0,175,100);
    			CS.SelectionForeColor = Color.FromArgb(0,32,15);
    			DataGridViewCellStyle LCS = DGVR.Cells[DGVR.Cells.Count - 1].Style;
    			LCS.BackColor = Color.FromArgb(50,50,50);
    			LCS.SelectionBackColor = Color.FromArgb(50,50,50);
    		}
    		else if(DGVR.Cells[0].Value.ToString() == "الإستقطاعات")
    		{
    			CurrRType = "الإستقطاعات";
    			DataGridViewCellStyle CS = DGVR.DefaultCellStyle;
    			CS.BackColor = Color.FromArgb(175,0,50);
    			CS.ForeColor = Color.FromArgb(32,0,0);
    			CS.Font = new Font("Times New Roman",12,FontStyle.Bold);
    			CS.SelectionBackColor = Color.FromArgb(175,0,50);
    			CS.SelectionForeColor = Color.FromArgb(32,0,0);
    			DataGridViewCellStyle LCS = DGVR.Cells[DGVR.Cells.Count - 1].Style;
    			LCS.BackColor = Color.FromArgb(50,50,50);
    			LCS.SelectionBackColor = Color.FromArgb(50,50,50);
    		}
    	}
    }
