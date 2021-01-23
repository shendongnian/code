    OpenFileDialog dlg = new OpenFileDialog();
    dlg.Filter = "Portable Document Format (*.pdf)|*.pdf";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
        _pdfDoc = new PDFLibNet.PDFWrapper();
        _pdfDoc.LoadPDF(dlg.FileName);
        _pdfDoc.CurrentPage = 1;
    
       PictureBox pic =new PictureBox();
       pic.Width=800;
       pic.Height=1024;
       _pdfDoc.FitToWidth(pic.Handle);
       pic.Height = _pdfDoc.PageHeight;
       _pdfDoc.RenderPage(pic.Handle);
       
       Bitmap _backbuffer = new Bitmap(_pdfDoc.PageWidth, _pdfDoc.PageHeight);
       using (Graphics g = Graphics.FromImage(_backbuffer))
       {
           _pdfDoc.RenderHDC(g.GetHdc);
           g.ReleaseHdc();
       }
       pic.Image = _backbuffer;
    }  
