    class PrintStuff : IDisposable
    {
        readonly IEnumerable<Whatever> data;
        readonly PrintDocument pd;
        Font font;
        private int currentIndex;
        public PrintStuff(IEnumerable<Whatever> data)
        {
            this.data = data;
            pd = new PrintDocument();
            pd.BeginPrint += OnBeginPrint;
            pd.PrintPage += OnPrintPage;
            pd.EndPrint += OnEndPrint;
        }
        public void Print()
        {
            pd.Print();
        }
        public void Dispose()
        {
            pd.Dispose();
        }
        private void OnBeginPrint(object sender, PrintEventArgs args)
        {
            font = new Font(FontFamily.GenericSansSerif, 12F);
            currentIndex = 0;
        }
        private void OnEndPrint(object sender, PrintEventArgs args)
        {
            font.Dispose();
        }
        private void OnPrintPage(object sender, PrintPageEventArgs args)
        {
            var x = Convert.ToSingle(args.MarginBounds.Left);
            var y = Convert.ToSingle(args.MarginBounds.Top);
            var lineHeight = font.GetHeight(args.Graphics);
            while ((currentIndex < data.Count())
                   && (y <= args.MarginBounds.Bottom))
            {
                args.Graphics.DrawWhatever(data.ElementAt(currentIndex), font, Brushes.Black, x, y);
                y += lineHeight;
                currentIndex++;
            }
            args.HasMorePages = currentIndex < data.Count();
        }
    }
