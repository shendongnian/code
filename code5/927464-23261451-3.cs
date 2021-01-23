    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        private int i = 0;
        private Timer time;
        public Form1()
        {
            InitializeComponent();
            time = new Timer();
            time.Tick += time_Tick;
            time.Interval = 1000;
            time.Start();
        }
        private void time_Tick(object e, EventArgs ea)
        {
            if (i < 100)
            {
                txt.Text = i.ToString();
                i++;
                time.Start();
            }
            
        }
      }
    }
