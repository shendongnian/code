    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Threading;
    using System.IO;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public static int Countername1;
    
            public Form1()
            {
                InitializeComponent();
                Countername1 = 0;
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                try
                {
                    Countername1++;
                    switch (Countername1)
                    {
                        case 1:
                            break;
    
                        case 2:
                            break;
    
                        case 3:
                            break;
    
                        case 4:
                            break;
    
                        case 5:
                            this.Close();
                            timer1.Stop();
                            break;
                    }
                    if (Countername1 == 5)
                    {
                        Countername1 = 0;
                    }
                }
                catch
                {
    
                }
            }
        }
    }
