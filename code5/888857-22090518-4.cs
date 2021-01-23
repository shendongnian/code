    using System;
    using System.Windows.Forms;
    public class TestAlertForm : Form 
    {
        readonly IntPtr HSHELL_FLASH = new IntPtr(0x8006);
        protected override void WndProc(ref Message m)
        {
            if (m.WParam == HSHELL_FLASH)
            {
                // TODO: DO WORK HERE
                // m.LParam <-- A handle to the window that is 'flashing'
                //              You should be able to match this to your target.
                MessageBox.Show("FLASH!");
            }
            base.WndProc(ref m);
        }
    }
