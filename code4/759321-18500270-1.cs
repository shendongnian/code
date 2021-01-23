        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int w = e.MarginBounds.Width / 2;
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Font printFont = new Font("Arial", 10);
            Bitmap logo = System.Drawing.SystemIcons.WinLogo.ToBitmap();
            int height = 100 + y;
            string tabDataText = "Hello World";
            var tabDataForeColor = Color.Blue;
            var txtDataWidth = e.Graphics.MeasureString(tabDataText, printFont).Width;
            e.Graphics.DrawImage(logo,
                e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (logo.Width / 2),
                e.MarginBounds.Top + (e.MarginBounds.Height / 2) - (logo.Height));
            using (var sf = new StringFormat())
            {
                height += logo.Height + 15;
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(tabDataText, new Font(this.Font.Name, 10),
                     new SolidBrush(tabDataForeColor),
                     e.MarginBounds.Left + (e.MarginBounds.Width / 2),
                     e.MarginBounds.Top + (e.MarginBounds.Height / 2) + (logo.Height / 2) + 15,
                     sf);
            }
            e.HasMorePages = false;
        }
