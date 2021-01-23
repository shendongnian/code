         string filename = textBox1.text;
         string path = System.IO.Path.Combine(@"E:\", filename + ".txt");
         System.IO.FileInfo file = new System.IO.FileInfo(path);
         file.Create();
         filename =string.Empty;
         textBox1.text=string.Empty;
