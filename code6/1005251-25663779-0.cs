    StreamWriter File1 = null;
    try
    {
        // Try to create the StreamWriter
        File1 = new StreamWriter(newPath);
    }
    catch (IOException)
    {
        /* Catch System.IO.IOException was unhandled
           Message=The process cannot access the file 'C:\Users\Dilan V 8
        */ Desktop\TextFile1.txt' because it is being used by another process.
        File1.Write(textBox1.Text);
        File1.Close();
        throw;
    }
