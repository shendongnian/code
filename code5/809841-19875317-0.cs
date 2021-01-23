    bool changedByCode = false;
    
    private void textBox1_TextChanged(object sender, EventArgs e)      
    {
        if(changedByCode) return;
    
        if (textBox1.Text == "a")
        {
            changedByCode = true;
            textBox1.Text = "";
            changedByCode = false;
            MessageBox.Show("Ok");
        }
        else
        {
             MessageBox.Show("No");
        }
    }
