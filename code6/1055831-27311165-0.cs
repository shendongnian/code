    class ButtonEx : Button
    {
        public bool IsInMouseDown { get; set; }
        protected override void WndProc(ref Message m)
        {
            const int WM_LBUTTONDOWN = 0x0201;
            try
            {
                if (m.Msg == WM_LBUTTONDOWN)
                    IsInMouseDown = true;
                base.WndProc(ref m);
            }
            finally //Make sure set the flag to false whatever happens.
            {
                if (m.Msg == WM_LBUTTONDOWN)//Required to fight with reentracy
                    IsInMouseDown = false;
            }
        }
    }
