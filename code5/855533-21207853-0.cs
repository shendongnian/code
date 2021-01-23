    private void button2_MouseDown(object sender, MouseEventArgs e) 
    {
      led18.Show();
    } 
 
    private void button2_MouseUp(object sender, MouseEventArgs e) 
    {
      led18.Hide();  
    }
    //below get automatically put into the design file...
    this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
    this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp); 
