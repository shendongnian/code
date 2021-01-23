    public static void WriteText(string filename, string text)
    {
        bool retry = true;
        while (retry)
        {
             try
             {
                  System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
                  file.Write(text);
                  file.Close();
              }
              catch(Exception exc)
              {
                    MessageBox.Show("File is probably locked by another process.");
                    // change your message box to have a yes or no choice
                    // yes doesn't nothing, no sets retry to false
              }
        }
    }
