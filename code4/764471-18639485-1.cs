    string text = "";
    using (var sr = new StreamReader("C:\\File1.txt"))
    {
         string line;
         while ((line = sr.ReadLine()) != null)
         {
              text += line + Environment.NewLine;
         }
    }
    aTextbox.Text = text;
