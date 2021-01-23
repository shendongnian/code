    private void timer1_Tick(object sender, EventArgs e)
        {
            myProgress += 0.05;
            label1.Text = String.Format("{0} %", myProgress.ToString("F2"));
            if(Math.Abs(myProgress % 2.00) < 0.1) progressBar1.Increment(1);
            if ((int) myProgress >= 100)
            {
                Form2 f2 = new Form2();
                f2.Show();
                timer1.Stop();
                
            }
            
        }
