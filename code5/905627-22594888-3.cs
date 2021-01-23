    private int lastLablePos;
        public Form1()
        {
            InitializeComponent();
            lastLablePos = panel1.Location.Y;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\test.txt");
            Label[] labels = new Label[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Text = lines[i];
            }
            foreach (Label lable in labels)
            {
                lable.Location = new Point(0, lastLablePos);
                lable.AutoSize = true;
                panel1.Controls.Add(lable);
                lastLablePos += 30;
            }
        }
