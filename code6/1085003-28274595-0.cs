        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke((Action)delegate
            {
                Button b = new Button();
                c.Controls.Add(b);
            });
        }
