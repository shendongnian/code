        protected override void WndProc(ref Message m)
        {
            const int WM_LBUTTONDBLCLK = 0x0203;
            switch (m.Msg)
            {
                case WM_LBUTTONDBLCLK:
                    {
                        if (Control.ModifierKeys.HasFlag(Keys.Shift))
                        { 
                            //Shift plus mouse left button double clicked
                        }
                        break;
                    }
            }
            base.WndProc(ref m);
        }
