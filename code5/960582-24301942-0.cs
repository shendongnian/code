    private StringBuilder data = new StringBuilder();
    private void button2_Click(object sender, EventArgs e)
    {
        if(data.Length > 0)
        {
            using(System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"D:\test.txt"))
            {
                file2.Write(data.ToString());
            }
        }
    }
        
    private void button1_Click(object sender, EventArgs e)
    {
        // Clear the previous store data
        data.Clear();
        
        // ...
            
        System.IO.StreamReader file = new System.IO.StreamReader("d:\\license.txt"); 
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains(s1) || line.Contains(s2))
            {
                sb.AppendLine(line);
                counter++;
            }
        }
        
        file.Close();
    }
