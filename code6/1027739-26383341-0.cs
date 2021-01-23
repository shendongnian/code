            var myValue = txtBox1.Text ?? "";
            var splittedValue = myValue.Split(',');
            if (splittedValue.Length != 3)
            {
                MessageBox.Show("Please enter a valid values !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtBox2.Text = (splittedValue[0]);
            txtBox3.Text = (splittedValue[1]);
            txtBox4.Text = (splittedValue[2]);
 
