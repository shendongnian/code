    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Drawing.Imaging;
    
    class PagedPrintDocument : PrintDocument {
        public int PageFrom { get; set; }
        public int PageTo { get; set; }
        public int Page { get; private set; }
    
        protected override void OnBeginPrint(PrintEventArgs e) {
            Page = 0;
            if (PageTo < PageFrom) e.Cancel = true;
            base.OnBeginPrint(e);
        }
    
        protected override void OnPrintPage(PrintPageEventArgs e) {
            while (++Page < PageFrom) {
                // Fake the pages that need to be skipped by printing them to a Metafile
                IntPtr hDev = e.Graphics.GetHdc();
                try {
                    using (var mf = new Metafile(hDev, e.PageBounds))
                    using (var gr = Graphics.FromImage(mf)) {
                        var ppe = new PrintPageEventArgs(gr, e.MarginBounds, e.PageBounds, e.PageSettings);
                        base.OnPrintPage(ppe);
                    }
                }
                finally {
                    e.Graphics.ReleaseHdc(hDev);
                }
    
            }
            // Print the real page
            base.OnPrintPage(e);
            // No need to continue past PageTo
            if (Page >= PageTo) e.HasMorePages = false;
        }
    }
