    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBox1.TextChanged+=new EventHandler(textBox_TextChanged);
            textBox2.TextChanged+=new EventHandler(textBox_TextChanged);            
        }
        void textBox_TextChanged(object sender, EventArgs e)
        {
            string text=(sender as TextBox).Text;
            if(!textBox1.Text.Equals(text)) { textBox1.Text=text; }
            if(!textBox2.Text.Equals(text)) { textBox2.Text=text; }
        }
    }
