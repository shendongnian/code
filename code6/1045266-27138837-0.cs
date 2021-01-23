    internal class MyReport : PrintDocument
    {
        internal class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
            public string Test { get; set; }
        }
        Product[] data = new Product[] {
            new Product {Name="Bike",   Price=600,      Date=DateTime.Now,              Test = "Some Test" },
            new Product {Name="Car",    Price=30000,    Date=DateTime.Now.AddDays(1),   Test = "Second Test" },
            new Product {Name="Train",  Price=1600,     Date=DateTime.Now.AddDays(2),   Test = "Some Test" },
            new Product {Name="Boat",   Price=13000,    Date=DateTime.Now.AddDays(3),   Test = "Second Test" },
            ... //Data goes here            
        };
        string[] colHeaders = { "Name", "Price", "Date", "Spacer1", "Spacer2", "Spacer3", "Spacer4", "Spacer5", "Spacer6", "Spacer7", "Test" };
        float[] colWidths = { 100.0F, 100.0F, 100.0F, 100.0F, 100.0F, 100.0F, 100.0F, 100.0F, 100.0F, 100.0F, 200.0F };
        //Column offset adjustments to account for orphaning (where a column straddles two pages)
        float[] colOffsets = { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        Font textFont = SystemFonts.MenuFont;
        Brush textBrush = SystemBrushes.MenuText;
        float colPadding = 25.0F;
        float rowHeight = 25.0F;
        float pageLeftOffset = 0.0f;
        int nextRow = 0;
        bool needMoreColumns = false;
        RectangleF bounds = RectangleF.Empty;
        StringFormat curFormat = new StringFormat();
        Graphics graphics = null;
        protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
        {
            base.OnQueryPageSettings(e);
        }
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            bounds = e.MarginBounds;
            graphics = e.Graphics;
            rowHeight = textFont.GetHeight(graphics) * 1.5f;
            curFormat.Alignment = StringAlignment.Near;
            RectangleF curRect = RectangleF.Empty;
            needMoreColumns = false;
            //Print Headers
            var tempFont = textFont;
            var tempBrush = textBrush;
            textFont = new Font(tempFont.FontFamily, 14f, FontStyle.Bold | FontStyle.Underline);
            textBrush = new SolidBrush(Color.DarkBlue);
            for (int col = 0; col < colHeaders.Length; col++)
            {
                curRect = SetCell(col, nextRow-2);
                DrawCell(colHeaders[col], curRect, Color.Empty);
            }
            textFont.Dispose();
            textBrush.Dispose();
            textFont = tempFont;
            textBrush = tempBrush;
            int curRow = 0;
            //Print Data
            for (int row = nextRow; row< data.Length; row++) 
            {
                curRow = row;
                var cli = data[row];
                //Print Name
                curRect = SetCell(0, row);
                DrawCell(cli.Name, curRect, Color.Empty);
                //Print Price (DrawRect around first one)
                curRect = SetCell(1, row);
                DrawCell(string.Format("{0:C}", cli.Price), curRect, Color.Red);
                //Print Date
                curRect = SetCell(2, row);
                DrawCell(string.Format("{0:MMMM dd, yyyy}", cli.Date), curRect, Color.Blue);
                //Print Test
                curRect = SetCell(10, row);
                DrawCell(cli.Test, curRect, Color.Green);
                if (curRect.Bottom > bounds.Bottom) break;
            }
            if (curRect.Bottom > bounds.Bottom || needMoreColumns)
            {
                e.HasMorePages = true;
                if (needMoreColumns)
                {
                    //Move over, don't move down
                    pageLeftOffset = pageLeftOffset + bounds.Width;
                }
                else
                {
                    //Move down one page, and back to the first columns
                    pageLeftOffset = 0f;
                    nextRow = curRow;
                }
                return;
            }
            e.HasMorePages = false;
        }
        private RectangleF SetCell(int col, int row)
        {
            float xoffset = 0;
            for (int x = 0; x < col; x++) xoffset += colWidths[x] + colOffsets[x] + colPadding;
            xoffset += colOffsets[col];
            //Columns stradling pages, move to the next page.
            if (xoffset - pageLeftOffset < 0 && Math.Abs(xoffset - pageLeftOffset) < colWidths[col])
            {
                colOffsets[col] = Math.Abs(xoffset - pageLeftOffset);
                xoffset += colOffsets[col];
            }
            RectangleF curRect = new RectangleF(
                (float)bounds.Left + xoffset - pageLeftOffset, 
                (float)bounds.Top + (float)(row-nextRow+2) * rowHeight, 
                colWidths[col], 
                textFont.GetHeight(graphics));  //This is the top left start position
            //Determine if there are columns off the right hand side of the page
            needMoreColumns |= curRect.Right > bounds.Right;
            return curRect;
        }
        private void DrawCell(string cellText, RectangleF curRect, Color color)
        {
            //Return if this cell isn't fully within this page
            if (!bounds.Contains(curRect)) return;
            graphics.DrawString(cellText, textFont, textBrush, curRect, curFormat);
            if (!color.IsEmpty)
            {
                curRect.Size = graphics.MeasureString(cellText, textFont).ToSize();
                curRect.Inflate(2f, 2f);  
                graphics.DrawRectangle(new Pen(color, 2F), curRect.X, curRect.Y, curRect.Width, curRect.Height);
            }
        }
    }
