    public void Test() {
        int cellWidth = 23;
        int usernameCellWith = 86;
        int maxNumberOfColumns = 32;
        int maxNumberOfRows = 24;
        float[] scheduleTableColumnWidths = new float[maxNumberOfColumns];
        scheduleTableColumnWidths[0] = usernameCellWith;
        for (int i = 1; i < maxNumberOfColumns; i++)
            scheduleTableColumnWidths[i] = cellWidth;
        using (MemoryStream stream = new MemoryStream()) {
            iTextSharp.text.Rectangle rect = PageSize.GetRectangle("A4");
            rect = new iTextSharp.text.Rectangle(rect.Height, rect.Width, 90);
            using (Document document = new Document(rect, 10f, 10f, 10f, 10f)) {
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                //Unless this code is just a sample, a new document is never open and NewPage() is implied so these four lines could just be document.Open();
                if (!document.IsOpen()) {
                    document.NewPage();
                    document.Open();
                }
                PdfPTable containerTable = new PdfPTable(1);
                containerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                containerTable.WidthPercentage = 100;
                PdfPTable scheduleTable = new PdfPTable(scheduleTableColumnWidths);
                //Loop through each row
                for (int iRow = 0; iRow < maxNumberOfRows; iRow++) {
                    //Loop through each column
                    for (int iColumn = 0; iColumn < maxNumberOfColumns; iColumn++) {
                        //Placeholder variable that will be instantiated within the if statements below
                        PdfPCell cell;
                        //On the first column (of every row)
                        if (0 == iColumn) {
                            cell = new PdfPCell(new Phrase("user " + iRow));
                        //On the second column of every other row starting with the first (zeroth) row
                        } else if ((iColumn == 1) && (iRow % 2 == 0)) {
                            cell = new PdfPCell();
                            //Have the cell span based on the current row number
                            cell.Colspan = iRow + 1;
                            //Set the color
                            cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#255C8A"));
                            //Tell the inner for loop that we've accounted for some cells already
                            iColumn += iRow;
                        //Every other cell
                        } else {
                            cell = new PdfPCell();
                        }
                        //This is weird
                        cell.FixedHeight = cellWidth;
                        //Regardless of the above, add a cell
                        scheduleTable.AddCell(cell);
                    }
                }
                containerTable.AddCell(scheduleTable);
                document.Add(containerTable);
                document.CloseDocument();
            }
        }
    }
