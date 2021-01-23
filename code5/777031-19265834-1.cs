    private void btnUpdate_Click(object sender, EventArgs e)
    {
            if (dataGridView2.SelectedCells.Count == 0 || dataGridView2.RowCount <= 1)
            {
                MessageBox.Show("There are no any records to update");
            }
            else
            {
                SqlConnection con = Helper.getconnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.Text;
                string PrjName = txtPrjNmae.Text;
                string Description = txtPrjdescription.Text;
                DateTime Date = dateUpdate.Value;
                dateUpdate.Format = DateTimePickerFormat.Custom;
                dateUpdate.CustomFormat = "dd/MM/yy";
                string Size = txtPrjSize.Text;
                string Manager = txtPrjManager.Text;
                cmd.CommandText = "Update Projects set Description='" + Description + "', DateStarted='" + Date + "',TeamSize='" + Size + "',Manager='" + Manager + "' where ProjectName= '" + PrjName + "' ";
                MessageBox.Show("Project Details are updated");
                dataGridView2.Update();
                dataGridView2.Refresh();
                cmd.ExecuteNonQuery();
                con.Close();
            }
                BindData3();            
        }   
