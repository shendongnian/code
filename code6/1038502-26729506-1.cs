    List<ExcelData> lstExcel = new List<ExcelData>();
    ExcelData fline = null;
    for (int i = 0; i < strLines.Length; i++)
    {
        line = RemoveWhiteSpace(strLines[i]).Trim();
        if (line.Length == 0)
            continue;
        string[] cells = line.Replace("\"", "").Split('\t');
    
        if (i > 0)
        {
            if (cells[1] != LastComment)
            {
                if (fline != null)
                    lstExcel.Add(fline);
                fline = new ExcelData();
                fline.SrNo++;
                fline.Footprint = cells[2].Replace(" ", "_");
                fline.Comment = cells[1].Replace(" ", "_");
                
                iCarousel++;
                if (iCarousel > 45)
                    iCarousel = 1;
                LastComment = cells[1];
                fline.Location = String.Format("{0}:{1}", CarouselName, iCarousel);
            }
            fline.Designator.Add(cells[0].Replace(" ", "_"));                        
            fline.Total++;
        }
    }
    ExportInExcel(lstExcel, @"D:\myExcel.xls");
    
