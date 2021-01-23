     private void Form1_Load(object sender, EventArgs e)
     {
         this.FormClosing += new FormClosingEventHandler(Inicio_FormClosing_1);
         this.FormClosed += new FormClosedEventHandler(Inicio_FormClosed_1);
     }
    
     private void Inicio_FormClosing_1(object sender, FormClosingEventArgs e)
     {
         //Things while closing
    
     }
    
     private void Inicio_FormClosed_1(object sender, FormClosedEventArgs e)
     {
         //Things when closed
     }
