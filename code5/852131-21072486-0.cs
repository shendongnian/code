    public class CellBackgroundImage : IPdfPCellEvent {
        private Image _background;
        public void SetImage(string path)  {
            _background = Image.GetInstance(path);
        }
        public void CellLayout(
            PdfPCell cell, Rectangle rectangle, PdfContentByte[] pcb) 
        {
            PdfContentByte cb = pcb[PdfPTable.BACKGROUNDCANVAS];
            cb.AddImage(_background, 
                rectangle.Width, 0, 0, rectangle.Height, rectangle.Left, rectangle.Bottom
            );
        }
    }
