    private void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.KeyCode == Keys.Enter) 
       { 
         textBox2.Text = String.Format("{0:000.00}", Convert.ToDouble(textBox2.Text));
       }
    }
