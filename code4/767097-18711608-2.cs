     static int count=0;// Global Variable declare somewhere at the top 
    
    protected void Button1_Click(object sender, EventArgs e)
            {
                count++;
                if (count == 1)
                {
                    TextBox1.Text = "a";
                }
                else if (count==2)
                {
                    TextBox1.Text = "b";
                }
                else if (count == 3)
                {
                    TextBox1.Text = "c";
                }
            }
