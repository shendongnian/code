    byte[] bytfile = Objects.GetFile(Convert.ToInt32(txtslno.Text.Trim()));
    Response.Clear();
    MemoryStream ms = new MemoryStream(bytfile);
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=test.pdf");
    Response.Buffer = true;
    ms.WriteTo(Response.OutputStream);
    Response.End();
