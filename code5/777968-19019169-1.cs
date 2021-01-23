    private void Form1_Load(object sender, EventArgs e)        
        {
            string path;
            path = System.IO.Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Replace("file:\\", "");
            StreamReader sr = new StreamReader(path +"/123.txt");
            richTextBox1.Text = sr.ReadToEnd();
        }
