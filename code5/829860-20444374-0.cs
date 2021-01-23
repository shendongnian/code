    public static void WriteToFile(string s)
        {
            String path=@"c:\message.txt";
            File.SetAttributes(path, FileAttributes.Normal);
            fs = new FileStream(path,
            FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
