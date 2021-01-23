    private void Reformat(string fileName)
    {
        //Give the column width according to column index.
        int[] cols = new int[] { 12, 35, 25, 15, 15 };
        string[] strLines = System.IO.File.ReadAllLines(fileName);
        StringBuilder sb = new StringBuilder();
        string line = string.Empty;
        string LastComment = string.Empty;
        string CarouselName = "Carousel";
        int iCarousel = 0;
        for (int i = 0; i < strLines.Length; i++)
        {
            line = RemoveWhiteSpace(strLines[i]).Trim();
            string[] cells = line.Replace("\"", "").Split('\t');                    
            for (int c = 0; c < cells.Length; c++)
                sb.Append(cells[c].Replace(" ", "_").PadRight(cols[c]));
            if (cells.Length > 1)
            {
                if (cells[1] != LastComment & i > 0)
                {
                    iCarousel++;
                    if (iCarousel > 45)
                       iCarousel = 1;
                    LastComment = cells[1];
                }
                if (i == 0)
                    sb.Append("Location".PadRight(15));
                else
                    sb.Append(String.Format("{0}:{1}", CarouselName, iCarousel).PadRight(15));
            }
            sb.Append("\r\n");
        }
    
        //System.IO.File.WriteAllText(fileName, sb.ToString());
        MessageBox.Show(sb.ToString());
    }
    private string RemoveWhiteSpace(string str)
    {
        str = str.Replace("  ", " ");
        if (str.Contains("  "))
            str = RemoveWhiteSpace(str);
        return str;
    }
