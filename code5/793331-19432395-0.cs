    string filePath = "";
    string fileData = "";
    using (FileStream fs = new FileStream(filePath, FileMode.Open))
    {
                    byte[] data = new byte[fs.Length];
                    fs.Seek(0, SeekOrigin.Begin);
                    fs.Read(data, 0, int.Parse(fs.Length.ToString()));
                    fileData = System.Text.Encoding.Unicode.GetString(data);
    }
