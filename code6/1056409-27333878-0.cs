    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string[] questions=new string[] {
                "Who is a Silk Worm?",
                "What does Sapience mean?",
                "What is Tainou?"
            };
            listBox1.DataSource=questions;
        }
    }
