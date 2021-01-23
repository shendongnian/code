    private void button1_Click(object sender, EventArgs e)
    {
       try
       {
         //do your database work here
       }
       catch(Exception ex)
       {
          textBox1.Text = textBox1.Text + ex.ToString();
       }
    }
