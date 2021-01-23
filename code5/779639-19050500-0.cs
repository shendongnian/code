    bool ifNew = true;
    Double num ,num2,;
    private void Add_Click(object sender, EventArgs e))
    {
       if(ifNew)
       {
     
        num =  Convert.ToDouble(textBox1.Text);
        textbox1.Clear();
        ifNew = false;
    
       }
       else
       {
        num2 = Convert.ToDouble(textBox1.Text);
       } 
    }
    
    private void Equals_Click(object sender, EventArgs e)
    {
       if(num1 > 0 && num2 > 0)
       { 
       textTotal.Text = string.Format("{0:N}",num1 + num2);
       }
     
    }
