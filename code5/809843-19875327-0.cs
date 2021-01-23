            public Form1()
            {
                InitializeComponent();
                textBox1.KeyUp+=new KeyEventHandler(textBox1_KeyUp);
            }
            private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (textBox1.Text == "a")
                {
                    textBox1.Text = "";
                    MessageBox.Show("Ok");
                }
                else
                {
                    MessageBox.Show("No");
                }
            }
