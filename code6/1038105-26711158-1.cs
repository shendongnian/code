    String[] allLines = richTextBox1
                        .Rtf
                        .Split( new string[] { Environment.NewLine },StringSplitOptions.None);
    dynamic linesWithoutEmptyLines = from itm in allLines 
                                     where itm.Trim() != "\\par" 
                                     select itm;
    richTextBox1.Rtf = string
                       .Join(Environment.NewLine, linesWithoutEmptyLines);
