    private string applicationFilePath = Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData), "Application.txt");
    private void button3_Click(object sender, EventArgs e)
    {
        File.WriteAllText(applicationFilePath, textBox1.Text);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        textBox1.Text = File.ReadAllText(applicationFilePath, Encoding.ASCII);
    }
