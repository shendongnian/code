     public string s = "Put you terribly long string here";
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //For responsiveness 
            textBox1.BeginInvoke(new Action(() =>
            {
                //Here's your logic
                for (int i = 0; i < s.Length; i += 1000)
                {
                    //This if is just for security
                    if (i+1000 > s.Length)
                    {
                        //Here's your AppendText
                        textBox1.AppendText(s.Substring(i, s.Length-i));
                    }
                    else
                    {
                        //And it's here as well
                        textBox1.AppendText(s.Substring(i, 1000));
                    }
                }
            }));
        }
