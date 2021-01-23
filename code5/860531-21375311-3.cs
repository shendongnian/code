    private void btnSubmit_Click(object sender, EventArgs e)
    {
            if (btnSubmit.Text == "Clear")
            {
                btnSubmit.Text = "Submit";
    
                txtpFirstName.Focus();
            }
            else
            {
               btnSubmit.Text = "Clear";
               int result = AddPatientRecord();
               if (result > 0)
               {
                   MessageBox.Show("Insert Successful");
                   LoadPatientRecords();
               }
               else
                   MessageBox.Show("Insert Fail");
             }
    }
