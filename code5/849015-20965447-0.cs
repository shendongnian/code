    public partial class Form1 : Form
    {        
        public Form1()
        {            
            InitializeComponent();
            intro();
        }
        private void fullScreen()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }
        private void intro()
        {
            pictureBox1.BackColor = Color.White;
            pictureBox1.SendToBack();
            Label introInfo = new Label();
            introInfo.Font = new Font("century gothic", 24, FontStyle.Bold);
            introInfo.ForeColor = Color.Cyan;
            introInfo.Text = "succes bro!";
            introInfo.Visible = true;
            introInfo.Location = new Point(100, 100);
            this.Controls.Add(introInfo);
                
        }        
    }
