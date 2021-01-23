    OpenFileDialog opn = new OpenFileDialog();
            if (opn.ShowDialog() == DialogResult.OK)
            {
               StreamReader sr = new StreamReader(opn.FileName);
               
               List<string[]> data = new List<string[]>(); 
               int Row = 0;
               while (!sr.EndOfStream)
               {
                   string[] Line = sr.ReadLine().Split(',');
                   data.Add(Line);
                   Row++;
                   Console.WriteLine(Row);
               }
               
            }
