       String line;
       while (!streamReader.EndOfStream)  // <= Check for end of file
       {
         line = streamReader.ReadLine(); // <=Get a single line
         if (line.Contains("Button1"))  // <= Check for condition ; line contains 'Button1'
            {
              this.txt.Text += line + "\n"; // <== Append text  with a newline 
            } 
         }
