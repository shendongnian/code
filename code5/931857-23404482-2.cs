    protected void btnAdd_Click(object sender, EventArgs e)
            {
                tblAdd.Visible = true;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                Label1.Visible = true;
                Label2.Visible = false;
                
                BindTable();
            } 
