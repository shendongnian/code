        List<long> Length = new List<long>();
        List<string> Movies = new List<string>();
        private async void button1_Click(object sender, EventArgs e)
        {
            await getLength(Regex.Split(richTextBox1.Text, "\r\n|\r|\n"));
            string text = "";
            for (int i = 0; i < Movies.Count; i++)
                text += Movies[i] + " Length: " + Length[i].ToString() + "\n";
            MessageBox.Show(text);
        }
        private async Task getLength(string[] movies)
        {
            Task[] tasks = new Task[movies.Length];
            for (int i = 0; i < movies.Length; i++)
            {
                Movies.Add(movies[i].Trim());
                Length.Add(0);
                tasks[i] = getOnesLength(i);
            }
            await Task.WhenAll(tasks);
        }
        private async Task getOnesLength(int index)
        {
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Movies[index]);
            hwr.Method = "HEAD";
            HttpWebResponse res = (HttpWebResponse) await hwr.GetResponseAsync();
            long len = res.ContentLength;
            long a = len / 1024;
            long b = a / 1024;
            Length[index] = b;
        }
