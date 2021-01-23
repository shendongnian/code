    public class WebSync
    {
        private System.Timers.Timer _tmrManifestHandler = new System.Timers.Timer();
        public WebSync(object id)
        {
            _tmrManifestHandler.Elapsed += new System.Timers.ElapsedEventHandler(_tmrManifestHandler_Tick);
            _tmrManifestHandler.Interval = 100;
            _tmrManifestHandler.Enabled = false;
        }
        public delegate void delBeginSync();
        public event delBeginSync evBeginSync;
        public void PreConnect()
        {
            while (true)
            {
                if (true /* just for testing*/)
                {
                    evBeginSync();
                    return;
                }
            }
        }
        public void Connect()
        {
            _tmrManifestHandler.Enabled = true;
            _tmrManifestHandler.Start();
        }
        private void _tmrManifestHandler_Tick(object sender, EventArgs e)
        {
            //NOT BEING 'HIT'
        }
    }
