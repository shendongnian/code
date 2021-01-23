    using (StreamWriter xyz = new StreamWriter(Path.Combine(File_Path, "xyz.txt"), true, Encoding.Unicode))
                {
                    foreach (string item in listBox1.Items)
                    {
                    xyz.WriteLine("ABC"); // or whatever you want
                    //xyz.WriteLine(item);
                    xyz.Flush();
                    }
                }
