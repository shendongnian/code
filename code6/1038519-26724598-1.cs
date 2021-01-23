    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace CloseWindowTest
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
            private System.Windows.Forms.Timer windowTimer;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                windowTimer = new System.Windows.Forms.Timer();
                windowTimer.Interval = 500;
                windowTimer.Tick += t_Tick;
                windowTimer.Enabled = true;
            }
            private void t_Tick(object sender, EventArgs e)
            {
                if (GetActiveWindowTitle().Contains("Notepad"))
                {
                    try
                    {
                        windowTimer.Enabled = false;
                        SendKeys.SendWait("Notepad Detected");
                        Environment.Exit(0);
                    }
                    catch (Exception wtf) { MessageBox.Show(wtf.ToString()); }
                }
            }
            private string GetActiveWindowTitle()
            {
                const int nChars = 256;
                StringBuilder Buff = new StringBuilder(nChars);
                IntPtr handle = GetForegroundWindow();
                if (GetWindowText(handle, Buff, nChars) > 0)
                {
                    return Buff.ToString();
                }
                return null;
            }
        }
    }
