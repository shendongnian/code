     {
                // this code is to display data from the database table to application 
                int stdid = Convert.ToInt32(txtId.Text); // convert in to integer to called in sqlcmd
                SqlConnection con = new SqlConnection("Data Source=MILK-THINK\\SQLEXPRESS;Initial Catalog=Student Details;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from info where Student_id=" + stdid,con); // pass the query with connection 
                SqlDataReader dr; // this will read the data from database
                dr = cmd.ExecuteReader();
                if(dr.Read()==true)
                {
                    txtName.Text = dr[1].ToString(); // dr[1] is a colum name which goes in textbox
                    cmbCountry.SelectedItem = dr[2].ToString(); // combobox selecteditem will be display
                   // for radio button we have to follow this method which in nested if statment
                    if(dr[3].ToString()=="Male") 
                    {
                        rdbMale.Checked=true;
    
                        
                    }
                    else if (dr[3].ToString() == "Female")
                    {
                        rdbFemale.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("There are no records");
                        dr.Close();
                    }
                }
                con.Close();
            }
