    try { 
        ...
        var headerDocumentLocation = saveLocation + documentName + "-h.html"
        using (var sw = new StreamWriter(new FileStream(headerDocumentLocation , FileMode.Create, FileAccess.Write))) {
            sw.Write(headerHtml);
        }
        ...
        Process p = new Process();
            p.StartInfo = new ProcessStartInfo {
                Arguments = "--header-html " + headerDocumentLocation + <other args>,
                FileName = <location of wkhtmltopdf>,
                WindowStyle = ProcessWindowStyle.Hidden
             };
            p.Start();
            p.WaitForExit();
        ...
    } finally { 
        if (File.Exists(headerDocumentLocation)) {
            File.Delete(headerDocumentLocation);
        }
    }
