    protected void DownloadChargeDataAsCSV(object sender, EventArgs e)
    {
        List<ChargeDetail> charges = ChargeDetail.GetDetailsForPatient(lblPatientNum.Text, lblPatientName.Text);
        
        string attachment = "attachment; filename=ChargeDetails.csv";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "text/csv";
        HttpContext.Current.Response.AddHeader("Pragma", "public");
        using (var memoryStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var streamReader = new StreamReader(memoryStream))
        using (var writer = new CsvWriter(streamWriter))
        {
            writer.WriteRecords(charges);
            memoryStream.Position = 0;
            HttpContext.Current.Response.Write(streamReader.ReadToEnd());
        }
        HttpContext.Current.Response.End();
    }
