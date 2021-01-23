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
         int totButtons = panel1.Controls.OfType<Button>().Count();
    
         Point curPos = new Point(0, 0);
         foreach(Button but in panel1.Controls.OfType<Button>())
         {
             but.Width = panel1.Width / totButtons; 
             but.Location = curPos;
             curPos = new Point(curPos.X + but.Width, 0);
         }
     }
