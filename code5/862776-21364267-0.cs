        while (dr.Read())
        {
            Form2 objform1 = new Form2();
            objform1.Show();
            this.Hide();
        }
        if(!dr.HasRows)
        {
           MessageBox.Show(this, "invalid username password");
        }
