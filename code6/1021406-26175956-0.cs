        private void startMyService()
        {
            Task.Factory.StartNew(fileMigration);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = (15 * 60 * 1000); //15 is minutes, so here is 15 minutes
            timer.Enabled = true;
        }
