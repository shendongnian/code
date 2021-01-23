    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0112) // WM_SYSCOMMAND
        {
            if (m.WParam == new IntPtr(0xF120)) // SC_RESTORE
            {
                // do smth before restore
                this.Size = new Size(666, 666);
            }
            else if (m.WParam == new IntPtr(0xF030)) // SC_MAXIMIZE
            {
                // do smth before maximize
            }
        }
        base.WndProc(ref m); // allow form to process this message
    }
