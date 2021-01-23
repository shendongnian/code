    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.lstClosedForms.Add(this.Name);
        }
     }
