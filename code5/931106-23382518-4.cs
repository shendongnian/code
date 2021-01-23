    using System;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace ConsoleApplication1 {
        public class TiledImageBackground : IPdfPCellEvent {
            protected Image image;
            public TiledImageBackground(Image image) {
                this.image = image;
            }
    
            public void CellLayout(PdfPCell cell, Rectangle position,
                PdfContentByte[] canvases) {
                PdfContentByte cb = canvases[PdfPTable.BACKGROUNDCANVAS];
                PdfPatternPainter patternPainter = cb.CreatePattern(image.ScaledWidth, image.ScaledHeight);
                image.SetAbsolutePosition(0, 0);
                patternPainter.AddImage(image);
                cb.SaveState();
                cb.SetPatternFill(patternPainter);
                cb.Rectangle(position.Left, position.Bottom, position.Width, position.Height);
                cb.Fill();
                cb.RestoreState();
            }
        }
    
        public class TiledBackground {
            public const String DEST = "results/tables/tiled_pattern.pdf";
            public const String IMG1 = "resources/images/ALxRF.png";
            public const String IMG2 = "resources/images/bulb.gif";
    
            private static void Main(string[] args) {
                Directory.CreateDirectory(Directory.GetParent(DEST).FullName);
                new TiledBackground().CreatePdf(DEST);
            }
    
            public void CreatePdf(String dest) {
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(dest, FileMode.Create));
                document.Open();
                PdfPTable table = new PdfPTable(2);
                PdfPCell cell = new PdfPCell();
                Image image = Image.GetInstance(IMG1);
                cell.CellEvent = new TiledImageBackground(image);
                cell.FixedHeight = 770;
                table.AddCell(cell);
                cell = new PdfPCell();
                image = Image.GetInstance(IMG2);
                cell.CellEvent = new TiledImageBackground(image);
                cell.FixedHeight = 770;
                table.AddCell(cell);
                document.Add(table);
                document.Close();
            }
        }
    }
