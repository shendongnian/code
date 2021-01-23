    private async void button1_Click(object sender, EventArgs e)
    {
        Stopwatch timer = new Stopwatch();
        var openFileDialog1 = new OpenFileDialog();
        progressBar1.Style = ProgressBarStyle.Marquee;
        progressBar1.MarqueeAnimationSpeed = 30;  
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {      
            timer.Start();
            textBox1.Text = await Task.Run(() => 
                GetFileMD5Hash(openFileDialog1.FileName));
            timer.Stop();
            lblTime.Text = timer.Elapsed.ToString();
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Increment(100);
        }
        progressBar1.MarqueeAnimationSpeed = 0;
    }
