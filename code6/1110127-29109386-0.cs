    private void ResizeForm ( string path, string fileName )
    {
        string src = path + @"\" + fileName + "_pre.pdf";
        string dest = path + @"\" + fileName + ".pdf";
    
        File.Move ( dest, src );
        using ( PdfReader pdf = new PdfReader ( src ) )
        {
            PdfDictionary pageDict;
            PdfArray cropBox;
            PdfArray mediaBox;
        
            float letterWidth = PageSize.LETTER.Width;
            float letterHeight = PageSize.LETTER.Height;
        
            int pageCount = pdf.NumberOfPages;
        
            for ( int i = 1; i <= pageCount; i++ )
            {
                pageDict = pdf.GetPageN ( i );
                cropBox = pageDict.GetAsArray ( PdfName.CROPBOX );
                mediaBox = pageDict.GetAsArray ( PdfName.MEDIABOX );
            
                cropBox [ 0 ] = new PdfNumber ( 30 );
                cropBox [ 1 ] = new PdfNumber ( 40 );
                cropBox [ 2 ] = new PdfNumber ( letterWidth + 30 );
                cropBox [ 3 ] = new PdfNumber ( letterHeight + 40 );
             
                mediaBox [ 0 ] = new PdfNumber ( 30 );
                mediaBox [ 1 ] = new PdfNumber ( 40 );
                mediaBox [ 2 ] = new PdfNumber ( letterWidth + 30 );
                mediaBox [ 3 ] = new PdfNumber ( letterHeight + 40 );
            
                pageDict.Put ( PdfName.CROPBOX, cropBox );
                pageDict.Put ( PdfName.MEDIABOX, mediaBox );
            }
            PdfStamper stamper = new PdfStamper ( pdf, new FileStream ( dest, FileMode.Create ) );
            stamper.Close ( );
        }
    }
