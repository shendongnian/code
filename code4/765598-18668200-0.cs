    private void button1_Click(object sender, EventArgs e)
    {
        string line;
    
        using (System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt"))
            using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"C:\test2.txt"))
                while ((line = file.ReadLine()) != null)
                {
                    string line2 = line.Substring(0, 38);
                    file2.WriteLine(line2);
                }
    }
