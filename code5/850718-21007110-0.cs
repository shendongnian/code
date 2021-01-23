    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Text;
    using System.Security.Cryptography;
    
    private string FilePath = "pinfile";
    
    private void BtnStore_Click(object sender, RoutedEventArgs e)
    {
        // Convert the PIN to a byte[].
        byte[] PinByte = Encoding.UTF8.GetBytes(TBPin.Text);
    
        // Encrypt the PIN by using the Protect() method.
        byte[] ProtectedPinByte = ProtectedData.Protect(PinByte, null);
    
        // Store the encrypted PIN in isolated storage.
        this.WritePinToFile(ProtectedPinByte);
    
        TBPin.Text = "";
    }
    
    private void WritePinToFile(byte[] pinData)
    {
        // Create a file in the application's isolated storage.
        IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
        IsolatedStorageFileStream writestream = new IsolatedStorageFileStream(FilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, file);
    
        // Write pinData to the file.
        Stream writer = new StreamWriter(writestream).BaseStream;
        writer.Write(pinData, 0, pinData.Length);
        writer.Close();
        writestream.Close();
    }
    
    private void BtnRetrieve_Click(object sender, RoutedEventArgs e)
    {
        // Retrieve the PIN from isolated storage.
        byte[] ProtectedPinByte = this.ReadPinFromFile();
    
        // Decrypt the PIN by using the Unprotect method.
        byte[] PinByte = ProtectedData.Unprotect(ProtectedPinByte, null);
    
        // Convert the PIN from byte to string and display it in the text box.
        TBPin.Text = Encoding.UTF8.GetString(PinByte, 0, PinByte.Length);
    
    }
    
    private byte[] ReadPinFromFile()
    {
        // Access the file in the application's isolated storage.
        IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
        IsolatedStorageFileStream readstream = new IsolatedStorageFileStream(FilePath, System.IO.FileMode.Open, FileAccess.Read, file);
    
        // Read the PIN from the file.
        Stream reader =  new StreamReader(readstream).BaseStream;
        byte[] pinArray = new byte[reader.Length];
    
        reader.Read(pinArray, 0, pinArray.Length);
        reader.Close();
        readstream.Close();
    
        return pinArray;
    }
