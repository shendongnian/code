    public static void Create(string urltoconvert, string savepath)
    {
        var doc = new PdfDocument();
        doc.LoadFromHTML(urltoconvert, false, true, true);
        doc.SaveToFile(savepath);
        doc.Close();
        System.Diagnostics.Process.Start(savepath);
    }
