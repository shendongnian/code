     SqlCommand cmd = new SqlCommand(@"INSERT INTO CustomerDetails
                         (Date, Contact_No, Name, Gender, Address, Email_ID)
    VALUES('" + this.dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + txtName.Text + "','" + Gender + "','" + txtAddress.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Information Added Successfully.", "Dairy Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLFunctions.Refresh(this.dataGridView1);
                clear();
