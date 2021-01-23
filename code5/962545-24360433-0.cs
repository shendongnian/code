    public Form1()
    {
        InitializeComponent();
      
        pictureBox1.MouseWheel += pictureBox1_MouseWheel;
    }
    
    void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
    {
      if(e.Delta > 0)
      {
          //up
      }
      else
      {
          //down
      }
    }
    
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        pictureBox1.Focus();
    }
