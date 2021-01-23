    System.IO.StreamReader file = null;
    private void button1_Click(object sender, EventArgs e)
    {
        int counter = 0;
        string line;
    
        // Read the file and display it line by line.
        if (file == null)
            file = new System.IO.StreamReader("c:\\test.txt");
        if (!file.EndOfStream)
        {
            string line = file.ReadLine();
            textBox1.Text = line;
        }
        else
        {
            MessageBox.Show("End");
            file.Close();
        }
    }
