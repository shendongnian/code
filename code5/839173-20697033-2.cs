    private void button3_Click(object sender, EventArgs e)
    {
        // save listBox into text file
        using(StreamWriter writer = new StreamWriter("yourFileFromWorkingDirectory.txt"))
        {
            foreach (string s in listBox1.Items)
            {
                writer.WriteLine(s);
            }
        }
    }
