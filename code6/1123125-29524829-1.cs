     public partial class Popup : Form
        {
            public static bool StayVisible { get; set; }
    
            private System.Windows.Forms.Timer timer1;
    
            public Popup()
            {
                StayVisible = true;
                this.timer1.Interval = 1000;
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
    
                InitializeComponent();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (!StayVisible) this.Close();
            }
            
        }
