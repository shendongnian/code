        public Form1()
            {
                InitializeComponent();
                this.KeyPreview = true;
    
                this.KeyDown += new KeyEventHandler(Form1_KeyDown);
    
    
            }
       void Form1_KeyDown(object sender, KeyEventArgs e)
      {
             if (e.KeyValue == 39)
        {
            button1.Location = new Point(button1.Location.X + 1, button1.Location.Y);
        }
        else if (e.KeyValue == 37)
        {
            button1.Location = new Point(button1.Location.X - 1, button1.Location.Y);
        }
     }
                 
