        public void ChangeInfo(string Newname, string NewFullname, string NewEmail)
        {
            using(SqlConnection con = new SqlConnection("MyconnectionString"))
            using (
                SqlCommand command =
                    new SqlCommand(
                        "UPDATE [Users] SET [UserName] = @UserName, [Fullname] = @NewFullName, [Email] = @NewWmail WHERE [ID] = @Id",
                        con))
            {
                command.Parameters.AddWithValue("@UserName", Newname);
                command.Parameters.AddWithValue("@NewFullName", NewFullname);
                command.Parameters.AddWithValue("@NewMail", NewEmail);
                command.Parameters.AddWithValue("Id", this.ID);
                
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
