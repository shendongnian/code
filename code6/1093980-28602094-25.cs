        protected override void OnResume()
        {
            base.OnResume();
            communicator.Resume();
        }
        protected override void OnPause()
        {
            communicator.Pause();
            base.OnPause();
        }
