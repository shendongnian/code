    public Rectangle
    {    
       this.Click += new System.EventHandler(Function);  
    }
    private void Function(object sender, System.EventArgs e)
    {
       if (((MouseEventArgs)e).Button == MouseButtons.Right)
       {
           //Your code         
       }
    }
