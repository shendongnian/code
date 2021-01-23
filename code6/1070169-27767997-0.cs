    var value = string.Format("{0,-10}", "TEST33");
    
    FileStream fs = File.OpenWrite("test.txt");
                
    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding(true);
    int preamble = enc.GetPreamble().Length;
    var bytes = enc.GetBytes(value);
                
    fs.Seek(preamble, SeekOrigin.Begin);
    fs.Write(bytes, 0, bytes.Length);
    
    fs.Close();
