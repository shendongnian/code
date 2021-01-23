         string filename = textBox1.text;
         string path = System.IO.Path.Combine(@"E:\", filename + ".txt");
         System.IO.FileInfo file = new System.IO.FileInfo(path);
         file.Create();
          if (File.Exists(path))
              {
               TextWriter tw = new StreamWriter(path, true);
               tw.WriteLine("The next line!");
               tw.Close(); 
             }
         filename =string.Empty;
         textBox1.text=string.Empty;
