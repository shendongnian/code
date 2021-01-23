    private static void addCellWithRowSpan(PdfPTable table, string text, int rowspan, bool colorStatus, bool fontStatus)
    {
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        iTextSharp.text.Font times;
        if (fontStatus == false)
        {
            times = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.NORMAL, Color.BLACK);
        }
        else
        {
            times = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.BOLD, Color.BLACK);
        }
        PdfPCell cell = new PdfPCell(new Phrase(text, times));
        cell.Rowspan = rowspan;
        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        if (colorStatus == true)
        {
            cell.BackgroundColor = new Color(179, 179, 179);
        }
        table.AddCell(cell);
    }
