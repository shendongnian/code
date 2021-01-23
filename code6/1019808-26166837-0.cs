    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Media;
    
    namespace delete
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                timer1.Enabled = true;
                timer1.Interval = 1000;
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                SoundPlayer sp = new SoundPlayer();
                sp.Play();
            }
        }
    }
