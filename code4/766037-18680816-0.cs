    if(num <= 15)
    {
       textBox1.Text = "0";
    }
    else
    {
       if(num <= 255)
       {
          textBox1.Text = "00";
       }
       else
       {
          if(num <= 4095)
          {
             textBox1.Text = "000";
          }
       }
    }
    
    textBox1.Text += num;
