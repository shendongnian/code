    private void Reformat(string fileName)
    {
        //Give the column width according to column index.
        int[] cols = new int[] { 15, 30, 15, 20, 12 };
        string[] strLines = System.IO.File.ReadAllLines(fileName);
    
        StringBuilder sb = new StringBuilder();
        string line = string.Empty;
        for (int i = 0; i < strLines.Length;i++ )
        {
            line = RemoveWhiteSpace(strLines[i]).Trim();
            string[] cells = line.Replace("\"", "").Split(new string[] {" "} , StringSplitOptions.None);
            for (int c = 0; c < cells.Length; c++)
                sb.Append(cells[c].PadRight(cols[c]));
            sb.Append("\r\n");
        }
    
        //System.IO.File.WriteAllText(fileName, sb.ToString());
        MessageBox.Show(sb.ToString());
    }
