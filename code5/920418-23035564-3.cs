     protected void abc_onclick(object sender, EventArgs e)
            {
                Button btnEdit = (Button)sender;
    
                GridViewRow grdrow = (GridViewRow)((Button)sender).NamingContainer;
                Label rowNumber = (Label)dgvHMDEditorialManage.Rows[grdrow.RowIndex].Cells[0].FindControl("mm");
                Label rowNumber1 = (Label)dgvHMDEditorialManage.Rows[grdrow.RowIndex].Cells[1].FindControl("mm1");
                Label rowNumber2 = (Label)dgvHMDEditorialManage.Rows[grdrow.RowIndex].Cells[2].FindControl("mm2");
    
                string abc = rowNumber.Text;
                string dealId = rowNumber1.Text;
                string dealTitle = rowNumber2.Text; ;
                //do something
            }
