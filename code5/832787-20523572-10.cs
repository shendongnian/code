    private void AnimationStep(object source, ElapsedEventArgs e)
    {
        // The following code needs to be executed in the context of the UI thread.
        // We need to use this.Invoke in Forms or this.Dispatcher.Invoke in WPF
        this.Invoke((Action)delegate()
        {
            // Move picture. Note that we don't need to update the display here
            // because the UI thread gets time to do its work while the timer waits
            // to fire below
            if (pictureBox1.Top > 20)
                pictureBox1.Top--;
            // Show other picture maybe. I use <= here because initially, the
            // position of the picture box may already smaller than 20.
            if (pictureBox1.Top <= 20)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
 
            // Or let the timer fire again if we still need to animate
            else
            {
                (source as System.Timers.Timer).Start();
            }
        }
    }
