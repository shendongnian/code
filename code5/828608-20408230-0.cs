        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Down:
                        Debug.WriteLine("Down Arrow Captured");
                        break;
                    case Keys.Up:
                        Debug.WriteLine("Up Arrow Captured");
                        break;
                    case Keys.Tab:
                        Debug.WriteLine("Tab Key Captured");
                        break;
                    case Keys.Control | Keys.M:
                        Debug.WriteLine("<CTRL> + M Captured");
                        break;
                    case Keys.Alt | Keys.Z:
                        Debug.WriteLine("<ALT> + Z Captured");
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
				
