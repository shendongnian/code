    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Timer tmr;
            public Form1()
            {
                InitializeComponent();
            
                tmr = new Timer();
                tmr.Interval = 3 * 1000; // 3 seconds
                tmr.Tick += new EventHandler(tmr_Tick);
                tmr.Start();
            }
            void tmr_Tick(object sender, EventArgs e)
            {
                label1.Visible = false;
                tmr.Stop();
            }
        }
    }
