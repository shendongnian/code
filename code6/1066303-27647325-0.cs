    int number = doc.InlineShapes.Count;
    MessageBox.Show(number.ToString()); // 0 to begin with
    foreach (Microsoft.Office.Interop.Word.Shape s in doc.Shapes) {
        MessageBox.Show(s.Type.ToString());
            if (s.Type.ToString() == "msoTextBox") {
                MessageBox.Show(s.TextFrame.TextRange.Text);
            } else if (s.Type.ToString() == "msoPicture") {
                s.ConvertToInlineShape();
            }
    }
    number = doc.InlineShapes.Count;
    MessageBox.Show(number.ToString());  // Now it's 1 as it should be
    InlineShape ils = doc.InlineShapes[1];
    ils.Select();
    application.Selection.Copy();
    IDataObject data = Clipboard.GetDataObject();
    if (data.GetDataPresent(DataFormats.Bitmap)) {
        Image image = (Image)data.GetData(DataFormats.Bitmap, true);
        image.Save("c:\\image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
