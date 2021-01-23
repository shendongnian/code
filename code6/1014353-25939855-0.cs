        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in Environment.GetCommandLineArgs())
            {
                Debug.WriteLine(item);
            }
        }
