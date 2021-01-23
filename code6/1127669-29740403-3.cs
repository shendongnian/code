    protected void grdTenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdTenant.SelectedRow;
            txtRPCode.Text  = row.Cells[1].Text;
    
            ModalEditTenant.Show();
        }
