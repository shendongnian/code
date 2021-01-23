    public byte[] GetExcelByteStream(string filename)
    {
        using (var workbook = new XLWorkbook(filename))
        {
                var worksheet = workbook.Worksheets.Add("Sample Sheet");
                worksheet.Cell("A1").Value = "Hello World!";
                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return ms.ToArray();
                }
        }
    }
