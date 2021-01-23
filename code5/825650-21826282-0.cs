    var docPath = Path.Combine(startupPath, filename1);
    var app = new Microsoft.Office.Interop.Word.Application();
    
    MessageFilter.Register();
    
    app.Visible = true;
    
    var doc = app.Documents.Open(docPath);
    
    doc.ShowGrammaticalErrors = false;
    doc.ShowRevisions = false;
    doc.ShowSpellingErrors = false;
    
    if (!Directory.Exists(startupPath + "\\" + filename1.Split('.')[0]))
    {
         Directory.CreateDirectory(startupPath + "\\" + filename1.Split('.')[0]);
    }
    
    //Opens the word document and fetch each page and converts to image
    foreach (Microsoft.Office.Interop.Word.Window window in doc.Windows)
    {
          foreach (Microsoft.Office.Interop.Word.Pane pane in window.Panes)
          {
                for (var i = 1; i <= pane.Pages.Count; i++)
                {
                     var page = pane.Pages[i];
                     var bits = page.EnhMetaFileBits;
                     var target = Path.Combine(startupPath + "\\" + filename1.Split('.')[0], string.Format("{1}_page_{0}", i, filename1.Split('.')[0]));
    
                     try
                     {
                         using (var ms = new MemoryStream((byte[])(bits)))
                         {
                              var image = System.Drawing.Image.FromStream(ms);
                              var pngTarget = Path.ChangeExtension(target, "png");
                              image.Save(pngTarget, ImageFormat.Png);
                         }
                     }
                     catch (System.Exception ex)
                     { }
             }
        }
    }
    doc.Close(Type.Missing, Type.Missing, Type.Missing);
    app.Quit(Type.Missing, Type.Missing, Type.Missing);
    MessageFilter.Revoke();
