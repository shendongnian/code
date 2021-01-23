    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pd=new PrintDocument();
            int index=0, count=0;
            pd.BeginPrint+=(s, ev) =>
            {
                // find page count from form label
                count=int.Parse(label1.Text);
            };
            pd.PrintPage+=(s, ev) =>
            {
                // for each page
                index++;
                // get form size
                var size=this.Size;
                // create bitmap of same size
                var bmp=new Bitmap(size.Width, size.Height);
                // draw form into bitmap
                this.DrawToBitmap(bmp, new Rectangle(Point.Empty, size));
                // draw bitmap into graphics, resize to fit paper margins
                ev.Graphics.DrawImage(bmp, new Rectangle(ev.MarginBounds.Location, ev.MarginBounds.Size));
                // create a font and draw on graphics the page number
                using(var font = new Font(FontFamily.GenericSansSerif, 16f))
                {
                    ev.Graphics.DrawString(index.ToString(), font, Brushes.Black, ev.MarginBounds.Location);
                }
                // check for final page
                ev.HasMorePages=index<count;
            };
            pd.EndPrint+=(s, ev) =>
            {
                // reset count and index
                index=0;
                count=0;
            };
            PaperSize paper=new PaperSize("MyCustomSize", 100, 65);
            paper.RawKind=(int)PaperKind.Custom;
            // set paper size
            pd.DefaultPageSettings.PaperSize=paper;
            // set paper margins appropriately
            pd.DefaultPageSettings.Margins=new Margins(10, 10, 10, 10);
            // call up the print preview dialog to see results
            PrintPreviewDialog dlg=new PrintPreviewDialog();
            dlg.Document=pd;
            dlg.ShowDialog();
        }
    }
