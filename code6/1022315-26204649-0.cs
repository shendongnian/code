     private void button1_Click(object sender, EventArgs e)
            {
                int a = 0;
                int b = 1;
                int c = 1;
                StringBuilder finalstring = new StringBuilder();
                listBox1.Text += a.ToString();
                listBox1.Text += b.ToString();
    
                for (int i = 0; i < 20; i++)
                {
                    c = b;
                    b = a + b;
                    a = c;
                    listBox1.Items.Add(b.ToString());
                }
                 
            }
