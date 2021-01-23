    private void button1_Click(object sender, EventArgs e) {
        int x = Convert.ToInt32(textBox1.Text);
        int y = Convert.ToInt32(textBox2.Text);
        PrintHeaders(x, y);
        for(int i = x; i <= y; i++) {
            if(i % 2 == 0) {
               int result = Factorial(i);   
               richTextBox1.Text += "==========|" + i + "|" + result + "|=============";
               richTextBox1.Text += Environment.NewLine; 
            }
        }
    }
