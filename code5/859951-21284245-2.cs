    private void button1_Click(object sender, EventArgs e)
    {
         if(!String.IsNullOrWhiteSpace(textBox1.Text) || !String.IsNullOrWhiteSpace(textBox2.Text))
         {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Dido\Documents\DataCars.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("insert into Login values('" + textBox1.Text + "','" + textBox2.Text + "')", con);
            con.Open();
            int Status=cmd.ExecuteNonQuery();
            con.Close();
            if(Status>0)
            {
                MessageBox.Show("Your registration was successfull!");
                Login frm1 = new Login();
                Global.GlobalVar = textBox1.Text;
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("no records updated!");
            }
          }
          else
          {
                MessageBox.Show("Please insert some text...");
          }
    }
