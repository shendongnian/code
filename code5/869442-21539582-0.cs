       private void buttonDivide_Click(object sender, EventArgs e)
       {
            int val1;
            int val2;
            if(!Int32.TryParse(textBox1.Text, out val1))
            {
                 MessageBox.Show("Please type a valid number!");
                 return;
            }
            if(!Int32.TryParse(textBox2.Text, out val2))
            {
                 MessageBox.Show("Please type a valid number!");
                 return;
            }
            if(val2 == 0)
            {
                 MessageBox.Show("Cannot divide by zero!");
                 return;
            }
            textBoxAns.Text = (val1 / val2).ToString();
            // The line above is an integer division, without decimals returned.
            // If you want a floating point result then you need
            textBoxAns.Text = (Convert.ToDouble(val1) / val2).ToString();
 
       }
