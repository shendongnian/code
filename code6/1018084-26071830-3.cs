            string filename = txtfilename.text;
            string path = System.IO.Path.Combine(@"D:\", filename + ".txt");
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter str = new StreamWriter(fs);
            str.BaseStream.Seek(0, SeekOrigin.End);
            str.Write("mytext.txt.........................");
            str.WriteLine(DateTime.Now.ToLongTimeString() + " " +
                          DateTime.Now.ToLongDateString());
            string addtext = "this line is added" + Environment.NewLine;
            str.Flush();
            str.Close();
            fs.Close();
