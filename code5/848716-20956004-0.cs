     private void Form1_Load(object sender, EventArgs e)
     {
         panel1.Dock = DockStyle.Fill;
         panel1.SizeChanged += panel1_SizeChanged;
     }
    
     private void panel1_SizeChanged(object sender, EventArgs e)
     {
         resizeButtons();
     }
    
     private void resizeButtons()
     {
         button1.Width = panel1.Width / 2;
         button1.Left = 0;
         button2.Width = panel1.Width / 2;
         button2.Left = panel1.Width / 2;
     }
