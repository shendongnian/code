    private void Form1_Load(object sender, EventArgs e)
    {
        // load text file lines into listBox
        string[] lines = File.ReadAllLines("yourFileFromWorkingDirectory.txt");
        foreach (string s in lines)
        {
            listBox1.Items.Add(s);
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        // add new line from textBox
        if (textBox1.Text != String.Empty) { listBox1.Items.Add(textBox1.Text); }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // remove selected line in listBox
        listBox1.Items.Remove(listBox1.SelectedItem);
    }
