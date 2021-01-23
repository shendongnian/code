        public void Timer_Tick(object sender, EventArgs e)
        {
            progressBar_Ladebalken.Value = i;
            label_Titel.Content = i + "%";
            if (i < 100)
            {
                i += 1;
            }
            else
            {
                i = 0;
                Timer.Stop();
                Window W = new MainWindow();
                // add the Close event handler here, and this will ensure your previous
                // logic of closing the Mutex when the MainWindow, not the LoadScreen, closes.
                W.Closed += (sender2, args) => Mutex.Close(); 
                W.Show();
                this.Close();
            }
        }
