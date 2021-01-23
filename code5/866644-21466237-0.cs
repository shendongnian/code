    private void button1_Click(object sender, EventArgs e)
    {
        string[] movies = richTextBox1.Text.Split(' '); // I used space as a separator here, but it depends on your code
        foreach (string item in movies)
        {
          HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(item);
          hwr.Method = "HEAD";
          HttpWebResponse res = (HttpWebResponse)hwr.GetResponse();
          long len = res.ContentLength;
          long a =len/1024;
          long b = a / 1024;
          MessageBox.Show(b.ToString()+" MB");
        }
    }
