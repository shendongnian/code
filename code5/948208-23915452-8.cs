    public class MyLocationTextExtractionStrategy : LocationTextExtractionStrategy {
        //Hold each coordinate
        public List<RectAndText> myPoints = new List<RectAndText>();
        //Automatically called for each chunk of text in the PDF
        public override void RenderText(TextRenderInfo renderInfo) {
            base.RenderText(renderInfo);
            //Get the bounding box for the chunk of text
            var bottomLeft = renderInfo.GetDescentLine().GetStartPoint();
            var topRight = renderInfo.GetAscentLine().GetEndPoint();
            //Create a rectangle from it
            var rect = new iTextSharp.text.Rectangle(
                                                    bottomLeft[Vector.I1],
                                                    bottomLeft[Vector.I2],
                                                    topRight[Vector.I1],
                                                    topRight[Vector.I2]
                                                    );
            //Add this to our main collection
            this.myPoints.Add(new RectAndText(rect, renderInfo.GetText()));
        }
    }
