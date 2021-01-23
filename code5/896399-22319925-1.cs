    var allTxt = Controls.OfType<TextBox>();
    for (int i = 1; i < 100; i++)
    {
        string docName = "deskDocumentName" + i;
        string docNo = "deskDocumentNo" + i;
        TextBox txtDocName = allTxt.First(txt => txt.Name == docName);
        TextBox txtDocNo = allTxt.First(txt => txt.Name == docNo);
        doc.belgename = txtDocName.Text;
        doc.belgeNo = txtDocNo.Text;
    }
