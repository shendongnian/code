    progressBar1.MarqueeAnimationSpeed = 50;
    Task.Run(() =>
        {
            // your long running code
        })
    .ContinueWith( () =>
        {
            this.Invoke((Action)delegate()
            {
                MessageBox.Show(id);
                pictureBox1.Visible = true;
            });
        });
