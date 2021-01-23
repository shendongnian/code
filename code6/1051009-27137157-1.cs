    FileStream fs = File.OpenRead(dlgOpen.FileName);
    byte[] picbyte1 = new byte[fs.Length];
    fs.Read(picbyte1, 0, (int)fs.Length); // <-- Add this one
    byte[] picbyte = Compress(picbyte1);
    // fs.Read(picbyte, 0, System.Convert.ToInt32(picbyte.Length)); // <-- And remove this one
    // ...
