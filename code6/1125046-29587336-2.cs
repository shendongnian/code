        private void Logingo_Click(object sender, EventArgs e)
        {
            int studentiD = 1;//Your ID
            string Password = "1234";//Your Password
            Student st = new Student(studentiD);
            if (st.getID() == studentiD && st.getPassword() == Password)
            {
                MessageBox.Show("Login Successed.");
                st.displays();//display ID,Password,Email,GPA
            }
            else
            {
                MessageBox.Show("Login Failed.");
            }
        }
