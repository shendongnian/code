    static void Main(string[] args)
    {    
        // Open your data file:
        FileStream fs = File.Open("data2.txt", FileMode.Open);
 
        // My txt file is in the UTF8 format so encode the inserted string with it:
        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding(true);
        var value = "EUR";
        var bytes = enc.GetBytes(value);
        // Seek to the position where you want to insert the string:
        Seek(fs, 2, 11);
        // Write the string bytes:
        fs.Write(bytes, 0, bytes.Length);
    
        fs.Close();
    }
    
