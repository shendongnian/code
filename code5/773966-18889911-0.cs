    Dispatcher.BeginInvoke(new Action(() =>
    {
            if (this.Opacity == 1)
            {
                timer1.Stop();
            }
            else
            {
                this.Opacity += .1;
            }
    }));
