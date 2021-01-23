        public Form1()
        {
            InitializeComponent();
            richEditControl1.KeyUp +=richEditControl1_Key;
        }
        private void richEditControl1_Key(object sender, KeyEventArgs e)
        {
            var currentText = richEditControl1.Text.Replace("\n", "");
            currentText = richEditControl1.Text.Replace("\r", " ");
            String result = currentText.Trim().Split(' ').LastOrDefault().Trim();
            Console.WriteLine(String.Format("{0}| {1}", DateTime.Now.ToLongTimeString(), result));
        }
