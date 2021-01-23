    private void button1_Click(object sender, EventArgs e)
    {
        if (this.choice == 1)
        {
            //this.box1 = Convert.ToInt32(textBox1.Text);
            //this.box1 = calculate1();
            //string result = "The Answer Is " + this.box1;
            //label2.Text = "5";
            //MessageBox.Show("Answer!", result, MessageBoxButtons.OK);
            label2.Text = "Hello World";
        }
        else if (this.choice == 2)
        {
            this.box1 = Convert.ToInt32(textBox1.Text);
            this.box2 = Convert.ToInt32(textBox2.Text);
        }
    }
