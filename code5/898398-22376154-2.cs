    public string ExportMemoryPdf(DataTable dtpdf, String Path)
    {
        string User = System.Web.HttpContext.Current.User.Identity.Name.ToString();
        string Date = DateTime.Now.ToString();
        string Year = DateTime.Now.ToString("yyyy");
        string Month = DateTime.Now.ToString("MM");
        string Day = DateTime.Now.ToString("dd");
        string Hour = DateTime.Now.ToString("hh");
        string Minutes = DateTime.Now.ToString("mm");
        string Seconds = DateTime.Now.ToString("ss");
        string FileName = User + Day + Month + Year + Hour + Minutes + Seconds;
        Request.QueryString["Position"] + "With the Filename: " + FileName;
        string Message = "The User Asked For a PDF File From the Table With the Filename: " + FileName;
        
        int columncount = dtpdf.Columns.Count;
        int rowcount = dtpdf.Rows.Count;
        Document pdf1 = new Document(PageSize.A4_LANDSCAPE.Rotate());
            pdf1.SetMargins(0, 0, 80, 50);
            iTextSharp.text.Font font20 = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10);
            PdfPTable table = new PdfPTable(columncount);
            string path = System.Web.HttpContext.Current.Server.MapPath(Path);
            table.WidthPercentage = 90;
            KIOSK.Classes.Header_Footer page = new Classes.Header_Footer();
            for (int z = 0; z < columncount; z++)
            {
                var sabersenao = dtpdf.Columns[z].ToString();
                table.AddCell(new Phrase(sabersenao, font20));
            }
            for (int u = 0; u < rowcount; u++)
            {
                int contador = 0;
                while (contador < columncount)
                {
                    var CamposCorrigidos = dtpdf.Rows[u].ItemArray[contador].ToString();
                    StringBuilder ConvPassword = new StringBuilder(CamposCorrigidos);
                    ConvPassword.Replace("&amp;", string.Empty);
                    ConvPassword.Replace("&nbsp;", string.Empty);
                    string CamposCorrigidos2 = ConvPassword.ToString();
                    table.AddCell(new Phrase(CamposCorrigidos2, font20));
                    contador += 1;
                }
            }
        var base64String = string.Empty;
        using (MemoryStream output = new MemoryStream())
        {
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdf1, output);
            pdfWriter.PageEvent = page;
            pdfWriter.add(table);
            
            bytes = output.ToArray();
            
            var base64String = Convert.ToBase64String(bytes);
        }
        return base64String;
    }
