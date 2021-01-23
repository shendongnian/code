     private void button1_Click(object sender, EventArgs e)
        {
           UserModel userModel = new UserModel();
            using (SqlConnection conn = new SqlConnection(@"Data Source=localhost; Initial   Catalog=Northwind; Integrated Security=True"))
            {
            //here your code to retrieve data from database
            userModel.FirstName = "";
            userModel.LastName = "";
            userModel.IdUser = 1;
            }           
            Form2 frm2 = new Form2(userModel);
            this.Hide();
            frm2.Show();
        }
