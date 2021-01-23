     con.Open();
                string Title = ddl_title.SelectedValue.ToString();
                string FirstName = txtname.Text;
                string MiddleName = txtmiddlename.Text;
                string LastName = txtlastname.Text;
                string Gender = ddl_gender.SelectedValue.ToString();
                string DateOfBirth = txtdateofbirth.Text;
                string Age = txtage.Text;
                string Cast = txtcast.Text;
                string Address = txtaddress.Text;
                string City = txtcity.Text;
                string Area = txtarea.Text;
                string PinCode = txtpincode.Text;
                SqlCommand cmd = new SqlCommand("Insert Into AddNewMemberWomenExecutiveCommittee Values('"+Title+"','"+FirstName+"','"+MiddleName+"','"+LastName+"','"+Gender+"','"+DateOfBirth+"','"+Age+"','"+Cast+"','"+Address+"','"+City+"','"+Area+"','"+PinCode+"')", con);
    
              
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
    
                    Response.Write("Insert Successfully");
                con.Close();
                GetData();
	
