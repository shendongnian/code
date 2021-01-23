    int progressVal=0;   
    private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            // int n = timer1.Interval;
            
        }
    
    private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            progressVal= progressBar1.Value;
    
            if(progressVal==progressBar1.Maximum)
            {
                timer1.Stop();
                textBox2.Text = "Loading done!";
            }
        }
