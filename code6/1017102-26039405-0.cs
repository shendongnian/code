    public class BluetoothLE
    {
        private MainWindow windowInstance;
        public BluetoothLE(MainWindow windowInstance) {
            this.windowInstance = windowInstance;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            windowInstance.Window_Loaded(this, null);
        }
    }
