        public void ProgressBarVegeta()
        {
            ProgressPowerVijand1.Value = (int)(vijand1.opladen());
            ProgressPowerVijand1.Maximum = 400;
            if (ProgressPowerVijand1.Value == 400)
            {
                ProgressBarHide();
            }
            //ProgressPowerVijand1.Value = Math.Min(0, ProgressPowerVijand1.Maximum);
        }
        public void ProgressBarHide()
        {
            ProgressPowerVijand1.Hide();
        }
