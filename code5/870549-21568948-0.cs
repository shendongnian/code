     private void btnSignInFaculty_Click(object sender, EventArgs e)
        {
            try
            {
                ...
                ....
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
    
                    MessageBox.Show("LogIn Sucessfully");
                    this.Hide();
                   //Use Overloaded Constructor..
                    FacultyLoadForm newForm = new FacultyLoadForm(this.txtBoxUserNameFaculty.Text , this.txtBoxPasswordFaculty.Text);
                    newForm.Show();
                }
                ...
                ...            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
