    private void CreatePDF(IList<string> HTMLData, string fileName) {
        //Create PDF document 
        Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
        HTMLWorker parser = new HTMLWorker(doc);
        StyleSheet styles = new StyleSheet();
        styles.LoadTagStyle(HtmlTags.TABLE, HtmlTags.SIZE, "6pt");
        styles.LoadTagStyle(HtmlTags.H3, HtmlTags.SIZE, "10pt");
        styles.LoadTagStyle(HtmlTags.H5, HtmlTags.SIZE, "6pt");
        parser.SetStyleSheet(styles);
        PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
        doc.Open();
        //Try/Catch removed
        foreach (var s in HTMLData) {
            StringReader reader = new StringReader(s);
            parser.Parse(reader);
            doc.NewPage();
        }
        doc.Close();
    }
