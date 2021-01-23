     public static void WriteText(string filename, string text, int numberOfTry = 3, Exception ex = null)
        {
            if (numberOfTry <= 0)
                throw new Exception("File Canot be copied", ex);
            try
            {
                var file = new System.IO.StreamWriter(filename);
                file.Write(text);
                file.Close();
            }
            catch (Exception exc)
            {
                WriteText(filename,text,--numberOfTry,ex);
            }
        }
