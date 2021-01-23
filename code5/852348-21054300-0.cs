       public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.button1.Click += new System.EventHandler(this.button_Click);
                this.button2.Click += new System.EventHandler(this.button_Click);
                this.button3.Click += new System.EventHandler(this.button_Click);
            }
    
            private void button_Click(object sender, EventArgs e)
            {
                Button button = (sender as Button);
                if (button != null)
                {
                    label1.Text = string.Format("You pressed {0}", button.Text);
                }
            }
        }
