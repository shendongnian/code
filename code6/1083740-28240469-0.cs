    public static void Main()
        {
           String file;
           file = "C:\\Temp\\test.doc";
           bool b=IsCloseFile(file);
           if (b)
                MessageBox.Show("File Open");
        }
    public static bool IsCloseFile(string file)
    {
        FileStream stream = null;
        try
        {
            stream = File.Open(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException e)
        {
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
        return false;
    }
}
