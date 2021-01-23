    namespace WindowsFormsLayoutButton
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                FlowLayoutButton button = new FlowLayoutButton();
                button.Left = 16;
                button.Top = 8;
                button.Width = 256;
                button.Height = 96;
                this.Controls.Add(button);
    
                button.Click += (o, args) => { MessageBox.Show("clicked"); };
            }
        }
    }
