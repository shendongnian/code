        private byte[] GetWordDocumentData(byte[] wordBytes, string path) //
        {
            // Save bytes to word file in temp dir, open, copy info. Then delete the temp file after.
            object x = System.Reflection.Missing.Value;
            string ext = Path.GetExtension(path).ToLower();
            string tmpPath = Path.ChangeExtension(Path.GetTempFileName(), ext);
            File.WriteAllBytes(tmpPath, wordBytes);
            // Open temp file with Excel Interop:
            Word.Documents docs = null;
            Word.ApplicationClass app = new Word.ApplicationClass();
            try
            {
                docs = app.Documents;
            }
            catch
            {
                app = new Word.ApplicationClass();
                docs = app.Documents;
            }
            object fpath = tmpPath;
            object visible = false;
            object readOnly = false;
            Word.Document doc = docs.Open(ref fpath, ref x, ref readOnly, ref x, ref x, ref x, ref x, ref x, ref x, ref x, ref x, ref visible, ref x, ref x, ref x, ref x);
            doc.Activate(); //New
            doc.ActiveWindow.Selection.WholeStory();
            doc.ActiveWindow.Selection.Copy();
            IDataObject data = Clipboard.GetDataObject();
            string documentText = data.GetData(DataFormats.Text).ToString();
            // Add text to pages.
            byte[] wordDoc = null;
            using (MemoryStream myMemoryStream = new MemoryStream())
            {
                Document myDocument = new Document();
                PdfWriter myPDFWriter = PdfWriter.GetInstance(myDocument, myMemoryStream); // REQUIRED.
                PdfPTable table = new PdfPTable(1);
                myDocument.Open();
                // Create a font that will accept unicode characters.
                BaseFont bfArial = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font arial = new Font(bfArial, 12);
                // If Hebrew character found, change page direction of documentText.
                PdfPCell page = new PdfPCell(new Paragraph(documentText, arial)) { Colspan = 1 };
                Match rgx = Regex.Match(documentText, @"\p{IsArabic}|\p{IsHebrew}");
                if (rgx.Success) page.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.AddCell(page);
                // Add image to document (Not in order with text...)
                foreach (Word.InlineShape ils in doc.InlineShapes)
                {
                    if (ils != null && ils.Type == Word.WdInlineShapeType.wdInlineShapePicture)
                    {
                        PdfPCell imageCell = new PdfPCell();
                        ils.Select();
                        doc.ActiveWindow.Selection.Copy();
                        System.Drawing.Image img = Clipboard.GetImage();
                        byte[] imgb = null;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imgb = ms.ToArray();
                        }
                        Image wordPic = Image.GetInstance(imgb);
                        imageCell.AddElement(wordPic);
                        table.AddCell(imageCell);
                    }
                }
                myDocument.Add(table);
                myDocument.Close();
                myPDFWriter.Close();
                wordDoc = myMemoryStream.ToArray();
            }
            Cleanup(x, tmpPath, app, doc);
            return wordDoc;
        }
