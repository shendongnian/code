    string[][] words = null;
    private void btnInput_Click(object sender, EventArgs e)
    {
       string line = "", contents = "";
       try
       {
           using (StreamReader file = new StreamReader("pers.txt"))
           {
              contents = file.ReadToEnd();
           }
           string[] lines = contents.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
           words = new string[lines.GetLength(0)][];
           for (int i = 0; i < lines.GetLength(0); i++)
           {
              string[] split_words = lines[i].Split(new char[] { ';' });
              words[i] = new string[split_words.GetLength(0)];
              for (int j = 0; j < split_words.GetLength(0); j++)
                  words[i][j] = split_words[j];
            }
            MessageBox.Show("File read", "Info");
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message, "File not found");
           return;
       }
    }
