        Product[] data = new Product[] {
            new Product {Name="Bike",Price=600, Date=DateTime.Now },
            new Product {Name="Car", Price=30000, Date=DateTime.Now.AddDays(1) }
        };
        string[] colHeaders = { "Name", "Price", "Date" };
        float[] colWidths = { 150.0F, 100.0F, 200.0F };
        float colPadding = 25.0F;
        float rowHeight = 25.0F;
        float verticalOffset = 50F;
        float horizontalOffset = 50.0F;
        Font textFont = SystemFonts.MenuFont;
        Brush textBrush = SystemBrushes.MenuText;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RectangleF startRect = new RectangleF(horizontalOffset, verticalOffset, colWidths[0], rowHeight);  //This is the top left start position
            RectangleF curRect = startRect;
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            //Print Headers
            for (int col = 0; col < colHeaders.Length; col++)
            {
                e.Graphics.DrawString(colHeaders[col], textFont, textBrush, curRect, format);
                curRect.Offset(colPadding + colWidths[col], 0F);  //This doesn't change startRect, since it is a struct
            }
            //Print Data
            int row = -1;
            foreach (var cli in data)
            {
                row++;      //Rewritten to use foreach as requested by user
                //Print Name
                curRect = startRect;
                curRect.Offset(0F, (float)(row + 1) * rowHeight * 1.5F);
                e.Graphics.DrawString(cli.Name, textFont, textBrush, curRect, format);
                //Print Price (DrawRect around first one)
                curRect.Offset(colPadding + colWidths[0], 0F);
                curRect.Width = colWidths[1];
                e.Graphics.DrawString(string.Format("{0:C}",cli.Price), textFont, textBrush, curRect, format);
                Rectangle border = Rectangle.Round(curRect);
                border.Offset(-5, -5);  //Text was being drawn in the top right of the curRect, Move the drawing rect up and left a bit to give a margin.
                e.Graphics.DrawRectangle(new Pen(Color.Red, 4F), border);
                //Print Date
                curRect.Offset(colPadding + colWidths[1], 0F);
                curRect.Width = colWidths[2];
                e.Graphics.DrawString(string.Format("{0:MMMM dd, yyyy}",cli.Date), textFont, textBrush, curRect, format);
                border = Rectangle.Round(curRect);
                border.Offset(-5, -5);  //Text was being drawn in the top right of the curRect, Move the drawing rect up and left a bit to give a margin.
                e.Graphics.DrawRectangle(new Pen(Color.Blue, 4F), border);
            }
        }
    }
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
