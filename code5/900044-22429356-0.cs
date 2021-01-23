    void Btn_addClick(object sender, EventArgs e)
    {
        if(listBox1.Items.Contains(textBox1.Text)) 
        {
            MessageBox.Show("This name already exists!");
        }
        else
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text="";
        }   
    }
