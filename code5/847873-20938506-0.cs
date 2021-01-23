    public Form1()
              {
                   InitializeComponent();
                   button1.MouseEnter += new EventHandler(button1_MouseEnter);
                   button1.MouseLeave += new EventHandler(button1_MouseLeave);
              }
    
              void button1_MouseLeave(object sender, EventArgs e)
              {
                   this.button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.img1));
              }
    
    
              void button1_MouseEnter(object sender, EventArgs e)
              {
                   this.button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.img2));
              }
