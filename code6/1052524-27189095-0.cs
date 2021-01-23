    protected MemoryStream printSelectionPDF()
    {
        var output = new MemoryStream();
        var doc = new Document(PageSize.A4);
        var writer = PdfWriter.GetInstance(doc, output);
        string Sur = DropDownListSurname.SelectedValue;
        string Cat = DropDownListCategory.SelectedItem.Text;
        string Pos = DropDownListPosition.SelectedItem.Text;
        string Resp = DropDownListResp.SelectedValue;
        doc.SetMargins(36, 36, 18, 18);
        GridView1.AllowPaging = false;
        GridView1.DataBind();
        doc.Open();
        CreatePDF(doc, rdBtnStaff.Checked, IncludeHistoricCheckBox.Checked, Sur, Cat, Pos, Resp);
        
        // copying stream
        output.Flush();
        output.Position = 0;
        var copyStream = new MemoryStream();
        output.CopyTo(copyStream);
        copyStream.Position = 0;
        // end copying stream
        
        doc.Close();
        GridView1.AllowPaging = true;
        return copyStream;
    }
