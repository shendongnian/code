    string memoValue = inboundSet.Fields["MEMO"].Value.ToString();
    if (RtfTags.IsRtfContent(memoValue))
    {     
      using (RichEditDocumentServer richServer = new RichEditDocumentServer())
      {
        string htmlText = string.Empty;
        richServer.RtfText = memoValue;
        CharacterProperties cp = richServer.Document.BeginUpdateCharacters(richServer.Document.Range);
        cp.FontName = "Arial";
        cp.FontSize = 12;
        richServer.Document.EndUpdateCharacters(cp);
        htmlText = richServer.HtmlText;
        callDetail.Memo = htmlText;
       }
    }
