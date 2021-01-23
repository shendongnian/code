    using System.IO;
    private void button3_Click(object sender, EventArgs e)
    {
        using (var stream = new FileStream(@"C:\Application.txt", FileMode.Create))
        using (var writer = new StreamWriter(stream, Encoding.ASCII))
            writer.Write(textBox1.Text);
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        using (var stream = new FileStream(@"C:\Application.txt", FileMode.Open))
        using (var reader = new StreamReader(stream, Encoding.ASCII))
            textBox1.Text = reader.ReadToEnd();
    }
