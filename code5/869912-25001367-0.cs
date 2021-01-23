        private async void _Timer_Tick(object sender, EventArgs e)
        {
            _Timer.Enabled = false;
            await Task.Run((() => DoStuff()));
            _Timer.Enabled = true;
        }
