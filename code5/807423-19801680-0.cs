        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 0)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(args[1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File: " + args[1] + "\r\n\r\n" + ex.ToString(), "Error Loading Image");
                }
            }
        }
