    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
    document.Open();
    //Adiciona os campos de assinatura
    document.Add(Assinatura());
    //fecha o documento ao finalizar a edição
    document.Close();
    //Prepara o download
    byte[] bytes = memoryStream.ToArray();
    memoryStream.Close();
    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment;filename=ControleDePonto.pdf");
    Response.Buffer = true;
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.BinaryWrite(bytes);
    Response.End();
