    public class MyImageRenderListener : iTextSharp.text.pdf.parser.IRenderListener {
        //For each page keep a list of various image info
        public Dictionary<int, List<ImageScaleInfo>> Pages = new Dictionary<int, List<ImageScaleInfo>>();
        //Need to manually change the page when using this
        public int CurrentPage { get; set; }
        //Not used, just interface contracts
        public void BeginTextBlock() { }
        public void EndTextBlock() { }
        public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo) { }
        //Called for each image
        public void RenderImage(iTextSharp.text.pdf.parser.ImageRenderInfo renderInfo) {
            //Get the basic image info
            var img = renderInfo.GetImage().GetDrawingImage();
            var imgWidth = img.Width;
            var imgHeight = img.Height;
            img.Dispose();
            //Get the current transformation matrix
            var ctm = renderInfo.GetImageCTM();
            var ctmWidth = ctm[iTextSharp.text.pdf.parser.Matrix.I11];
            var ctmHeight = ctm[iTextSharp.text.pdf.parser.Matrix.I22];
            //Create new key for our page number if it doesn't exist already
            if (!this.Pages.ContainsKey(CurrentPage)) {
                this.Pages.Add(CurrentPage, new List<ImageScaleInfo>());
            }
            //Add our image info to this page
            this.Pages[CurrentPage].Add(new ImageScaleInfo(imgWidth, imgHeight, ctmWidth, ctmHeight));
        }
    }
