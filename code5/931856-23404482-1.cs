    protected void btnSave_Click(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    btnAdd.Visible = true;
                    btnDelete.Visible = true;
                    Label2.Visible = true;
                    tblAdd.Visible = false;
                    Label2.Text = "Successfully Added";
                    add();
    
                    BindTable();
                }
    
                txtName.Text = "";
            }
