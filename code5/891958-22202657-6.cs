    //Test file that we'll create with an embedded font
    var file1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    
    //Secondary file that we'll try to re-use the font above from
    var file2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test2.pdf");
    
    //Path to font file that we'd like to use
    var fontFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ROCK.TTF");
    
    //Create a basefont object
    var font = BaseFont.CreateFont(fontFilePath, BaseFont.WINANSI, true);
    
    //Get the name that we're going to be searching for later on.
    var searchForFontName = font.PostscriptFontName;
    
    //Step #1 - Create sample document
    //The below block creates a sample PDF file with an embedded font in an AcroForm, nothing too special
    using (var fs = new FileStream(file1, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
    
                //Create our field, set the font and add it to the document
                var tf = new TextField(writer, new iTextSharp.text.Rectangle(50, 50, 400, 150), "first-name");
                tf.Font = font;
                writer.AddAnnotation(tf.GetTextField());
    
                doc.Close();
            }
        }
    }
    
    //Step #2 - Look for font
    //This uses a stamper to draw on top of the existing PDF using a font already embedded
    using (var fs = new FileStream(file2, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var reader = new PdfReader(file1)) {
            using (var stamper = new PdfStamper(reader, fs)) {
    
                //Try to get the font file
                var f = findFontInForm(reader, searchForFontName);
    
                //Make sure we found something
                if (f != null) {
    
                    //Draw some text
                    var cb = stamper.GetOverContent(1);
                    cb.BeginText();
                    cb.MoveText(200, 400);
                    cb.SetFontAndSize(f, 72);
                    cb.ShowText("Hello!");
                    cb.EndText();
                }
            }
        }
    }
