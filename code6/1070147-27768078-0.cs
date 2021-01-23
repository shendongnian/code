    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    #endregion
    
    
    namespace CSUACSelfElevation
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
    
    
            private void MainForm_Load(object sender, EventArgs e)
            {
                // Update the Self-elevate button to show a UAC shield icon.
                this.btnElevate.FlatStyle = FlatStyle.System;
                SendMessage(btnElevate.Handle, BCM_SETSHIELD, 0, (IntPtr)1);
            }
    
            [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
            static extern int SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);
    
            const UInt32 BCM_SETSHIELD = 0x160C;
    
    
            private void btnElevate_Click(object sender, EventArgs e)
            {
                // Launch itself as administrator
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Application.ExecutablePath;
                proc.Verb = "runas";
    
                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    // The user refused to allow privileges elevation.
                    // Do nothing and return directly ...
                    return;
                }
    
                Application.Exit();  // Quit itself
            }
        }
    }
