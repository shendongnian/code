    Microsoft.Office.Interop.Word.Application myWordApp = new Microsoft.Office.Interop.Word.Application();
    Document myWordDoc = new Document();
    object missing = System.Type.Missing;
    object path1= path + filename + ".doc";
    myWordDoc = myWordApp.Documents.Add(path1, missing, missing, missing);
    foreach (Microsoft.Office.Interop.Word.Window window in myWordDoc.Windows)
    {
        foreach (Microsoft.Office.Interop.Word.Pane pane in window.Panes)
        {
            for (var i = 1; i <= pane.Pages.Count; i++)
            {
                var bits = pane.Pages[i].EnhMetaFileBits;
                var target =path1 + "_image.doc";
                try
                {
                    using (var ms = new MemoryStream((byte[])(bits)))
                    {
                        var image = System.Drawing.Image.FromStream(ms);
                        var pngTarget = Path.ChangeExtension(target, "png");
                        image.Save(pngTarget, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                catch (System.Exception ex)
                { }
            }
        }
    }
    myWordDoc.Close(Type.Missing, Type.Missing, Type.Missing);
    myWordApp.Quit(Type.Missing, Type.Missing, Type.Missing);
