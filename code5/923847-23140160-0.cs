    private void Form1_Load(object sender, EventArgs e)
    {   
      System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
      timer1.Interval=1000;//1 second
      timer1.Tick += new System.EventHandler(timer1_Tick);
      timer1.Start();
      progressBar1.Maximum = 20;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
         //do whatever you want
         if(progressBar1.Value==progressBar1.Maximum) 
            timer1.Stop();
         else
            progressBar1.Value+=1;
    }
