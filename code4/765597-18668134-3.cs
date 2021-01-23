    private void button1_Click(object sender, EventArgs e)
        {
            string line, line2;
    
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                line2 = line.Substring(0, 38);
                using (System.IO.StreamWriter files = new System.IO.StreamWriter(@"C:\test2.txt",true))
                {
                    files.WriteLine(line2);
                }
            }
    
            file.Close();
        }
