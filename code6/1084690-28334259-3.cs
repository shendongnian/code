        public void LaunchProc(int itemId)
        {
            var launcher = new ProcessLauncher<int>("someapp.exe", "/id=" + itemId, itemId);
            launcher.Exited += launcher_Exited;
            launcher.Start();
        }
        void launcher_Exited(object sender, ProcessExitedEventArgs<int> e)
        {
            var itemId = e.Key;
            var output = e.Output;
            // Process output and associate it to itemId.
        }
