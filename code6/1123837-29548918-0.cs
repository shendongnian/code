    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            // WM_PASTE
            case (0x0302):
                // You can interrupt here, interept or pass by. Do what You need
                MessageBox.Show("PASTE");
                break;
        }
        base.WndProc(ref m);
    }
