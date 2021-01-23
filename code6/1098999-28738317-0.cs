    Blink b = new Blink();
    b.Text(label1, "Hello World");
    class Blink
    {
        int BlinkCount = 0;
        private Label _info;
        private Timer _tmrBlink;
        public void Text(Label info, string message)
        {
            _info = info;
            _info.Text = message;
            _tmrBlink = new Timer();
            _tmrBlink.Interval = 250;
            _tmrBlink.Tick += new System.EventHandler(tmrBlink_Tick);
            _tmrBlink.Start();
        }
        private void tmrBlink_Tick(object sender, EventArgs e)
        {
            BlinkCount++;
            if (_info.BackColor == System.Drawing.Color.Khaki)
            {
                _info.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                _info.BackColor = System.Drawing.Color.Khaki;
            }
            if (BlinkCount == 4)
            {
                _tmrBlink.Stop();
                BlinkCount = 0;
            }
        }
    }
