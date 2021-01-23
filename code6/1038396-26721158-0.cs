     public void do_name()
        {
            string search_text = "PCB";
            string old;
            string n = "";
            StreamReader sr = File.OpenText(textBox1.Text);
            while ((old = sr.ReadLine()) != null)
            {
                if (!old.Contains(search_text))// || !old.Contains(next_text)) 
                {
                    n += old + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(textBox1.Text, n);
        }
        public void do_name1()
        {
            string next_text = "DOC";
            string old;
            string n = "";
            StreamReader sr = File.OpenText(textBox1.Text);
            while ((old = sr.ReadLine()) != null)
            {
                if (!old.Contains(next_text))// || !old.Contains(next_text)) 
                {
                    n += old + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(textBox1.Text, n);
        }
        Dictionary<string, int> namesForCarousels = new Dictionary<string, int>();
        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            string filename_noext = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\files";
            ofd.Filter = "TXT files (*.txt)|*.txt";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename_noext = System.IO.Path.GetFileName(ofd.FileName);
                path = Path.GetFullPath(ofd.FileName);
                textBox1.Text = path;
                do_name();
                do_name1();
                //MessageBox.Show(filename_noext, "Filename"); - - -> switching.grf
                //MessageBox.Show(path, "path");
                //Give the column width according to column index.
                int[] cols = new int[] { 15, 15, 25, 15, 15 };
                string[] strLines = System.IO.File.ReadAllLines(textBox1.Text);
                StringBuilder sb = new StringBuilder();
                string line = string.Empty;
                string LastComment = string.Empty;
                string CarouselName = "Carousel";
                int iCarousel = 0;
                for (int i = 0; i < strLines.Length; i++)
                {
                    line = RemoveWhiteSpace(strLines[i]).Trim();
                    string[] cells = line.Replace("\"", "").Split('\t');
                    
                    for (int c = 0; c < cells.Length; c++)
                        sb.Append(cells[c].Replace(" ", "_").PadRight(cols[c]));
                    if (cells.Length > 1)
                    {
                        var name = cells[1];
                        int carouselNumber;
                        if (namesForCarousels.TryGetValue(name, out carouselNumber) == false)
                        {
                            carouselNumber = iCarousel++;
                            namesForCarousels[name] = carouselNumber;
                        }
                        if (i == 0)
                            sb.Append("Location".PadRight(15));
                        else
                            sb.Append(String.Format("{0}:{1}", CarouselName, carouselNumber).PadRight(15));
                    }
                    sb.Append("\r\n");
                }
                System.IO.File.WriteAllText(textBox1.Text, sb.ToString());
               // do_name1();
                Application.Exit();
            }
        }
