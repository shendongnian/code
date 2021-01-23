    //Read All Bytes
    byte[] fileBytes = File.ReadAllBytes(openFileDialog1.FileName.ToString());
    
    //Data that needs to added, converted to bytes, Better off making a function for this
    String str = "Data to be added";
    byte[] newBytes = new byte[str.Length * sizeof(char)];
    System.Buffer.BlockCopy(str.ToCharArray(), 0, newBytes, 0, newBytes.Length);
    //Add the two byte arrays, the file bytes, the new data bytes
    byte[] fileBytesWithAddedData = new byte[ fileBytes.Length + newBytes.Length ];
    System.Buffer.BlockCopy( fileBytes.Length, 0, fileBytesWithAddedData, 0, fileBytes.Length );
    System.Buffer.BlockCopy( newBytes, 0, fileBytesWithAddedData, fileBytes.Length, newBytes.Length );
    //Write to new file
    File.WriteAllText(@"D:\result.png", fileBytesWithAddedData);
