     public class MyPdfSplitter : PdfSplitter
     {
        private readonly string _destFolder;
        private int _pageNumber;
        public MyPdfSplitter(PdfDocument pdfDocument, string destFolder) : base(pdfDocument)
        {
            _destFolder = destFolder;
        }
        protected override PdfWriter GetNextPdfWriter(PageRange documentPageRange)
        {
            _pageNumber++;
            return new PdfWriter(Path.Combine(_destFolder, $"p{_pageNumber}.pdf"));
        }
    }
