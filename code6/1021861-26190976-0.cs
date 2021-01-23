                    SqlCommand Command = new SqlCommand();
                    Command.Connection = MyConnection;
                    Command.CommandText =
                        "Insert into Employees (ID, Name, Last_name, Username, Password, E_mail, Address, administrator_rights)"
                        + "values(@ID, @Name, @Last_name, @Username, @Password, @E_mail,Address, @admin_rights )";
    
                Command.Parameters.Add("@ID", 1); // some generated number
                Command.Parameters.Add("@Name", TextBoxName.Text);
                Command.Parameters.Add("@Last_name", TextBoxLastName.Text);
                Command.Parameters.Add("@Username", TextBoxUserName.Text);
                Command.Parameters.Add("@Password", TextBoxPassword.Text);
                Command.Parameters.Add("@E_mail", TextBoxEmail.Text);
                Command.Parameters.Add("@Address", TextBoxAddress.Text);
                Command.Parameters.Add("@admin_rights", CheckBoxAdminRights.Checked);
    
                using (MyConnection)
                {
                    Command.ExecuteNonQuery();
                }
