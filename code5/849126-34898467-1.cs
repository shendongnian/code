    var config = new GlobalConfig().SetMargins(0, 0, 0, 0).SetPaperSize(PaperKind.A4);
    				
    var pdfWriter = new SynchronizedPechkin(config);
    
    var bytes = pdfWriter.Convert(new Uri(dataUrl));
    
    Response.BinaryWrite(bytes);
