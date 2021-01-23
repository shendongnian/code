    private static byte[] GeneratePdf(Dictionary<String, String> formKeys, String pdfPath)
        {
            var templatePath = System.Web.HttpContext.Current.Server.MapPath(pdfPath);
            var reader = new PdfReader(templatePath);
            var outStream = new MemoryStream();
            var stamper = new PdfStamper(reader, outStream);
            var form = stamper.AcroFields;
            form.GenerateAppearances = true; //Added this line, fixed my problem
            var fieldKeys = form.Fields.Keys;
            foreach (KeyValuePair<String, String> pair in formKeys)
            {
                if (fieldKeys.Any(f => f == pair.Key))
                {
                    form.SetField(pair.Key, pair.Value);
                }
            }
            stamper.Close();
            reader.Close();
            return flattenPdf(outStream.ToArray());
        }
