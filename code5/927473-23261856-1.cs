     private void button_Click(object sender, EventArgs e)
     {  
           string[] values = textBox1.Text.Split('#');
            if (values.Length >= 5)
            {
                textBox2.Text = values[0];
                textBox3.Text = values[1];
                textBox4.Text = values[2];
                textBox5.Text = values[3];
                textBox6.Text = values[4];
                //change the destination
                 if (values.Length == 5)
                    textBox1.Text = textBox1.Text.Substring(9); 
                else if (values.Length > 5)
                    textBox1.Text = textBox1.Text.Substring(10); 
            }
      }
