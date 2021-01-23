    bool ifNew = true;
    double num1 ,num2,result;
    private void Add_Click(object sender, EventArgs e))
    {
       if(ifNew)
       {
     
        num1 =  Convert.ToDouble(textBox1.Text);
        textbox1.Clear();
        ifNew = false;
        result += num1;
    
       }
       else
       {
        num2 = Convert.ToDouble(textBox1.Text);
        textbox1.Clear();
        result += num2;
        num1 = 0D;
        num2 = 0D;
        ifNew = true;
       } 
      
    }
    
    private void Equals_Click(object sender, EventArgs e)
    {
       textboxl.Text = string.Format("{0:N}",result);
    }
