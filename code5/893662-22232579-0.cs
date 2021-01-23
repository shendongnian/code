           bool IsAdminUser=false; 
           while (myReader.Read())
            {
                count = count + 1;
                IsAdminUser = myReader["permissions"].ToString().Equals("Admin") ? true : false;
            }
            if (count == 1 && IsAdminUser==true)
            {
                MessageBox.Show("User is Admin!");
                this.Hide();
                AdminForm adminForm = new AdminForm ();
                adminForm.ShowDialog();
            }
            else if (count == 1)
            {
                MessageBox.Show("Uspešno ste se prijavili!");
                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else if (count > 1)
            {
                MessageBox.Show("Dvojno uporabniško ime in geslo!");
                this.Hide();
            }
