            string LoggedInUserName = String.Empty;
            while (myReader.Read())
            {
                count = count + 1;
                IsAdminUser = myReader["dovoljenja"].Equals("Admin");
                LoggedInUserName = myReader["FirstName"].ToString()+
                                   myReader["LastName"].ToString();
            }
            else if (count == 1)
            {
                MessageBox.Show("Uspešno ste se prijavili!");
                this.Hide();
                Form3 f3 = new Form3(LoggedInUserName);
                f3.ShowDialog();
            }
