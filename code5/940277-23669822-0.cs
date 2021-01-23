    try {
          inFile = new System.IO.FileStream(inputFileName,
                                    System.IO.FileMode.Open,
                                    System.IO.FileAccess.Read);
          binaryData = new Byte[inFile.Length];
          long bytesRead = inFile.Read(binaryData, 0,
                               (int)inFile.Length);
          inFile.Close();
       }
       catch (System.Exception exp) {
          // Error creating stream or reading from it.
          System.Console.WriteLine("{0}", exp.Message);
          return;
       }
    
       // Convert the binary input into Base64 UUEncoded output. 
       string base64String;
       try {
           base64String = 
             System.Convert.ToBase64String(binaryData, 
                                    0,
                                    binaryData.Length);
       }
       catch (System.ArgumentNullException) {
          System.Console.WriteLine("Binary data array is null.");
          return;
       }
