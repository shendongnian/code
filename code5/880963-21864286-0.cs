    private void uxNumber_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
                int num = Convert.ToInt32(((GradientButton)sender).Text);
            if (this.uxPIN.Text.Length < 4)
                uxPIN.Text += num;    
            else
            SystemSounds.Beep.Play();
        }
    }
