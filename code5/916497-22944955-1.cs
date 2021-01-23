    Using (MemoryStream ms = new MemoryStream())
    {
        PdfReader rdr = new PdfReader(pdftemplate);
        PdfStamper stm = new PdfStamper(rdr, ms);
        AcroFields fields = stm.AcroFields;
        foreach (var de in rdr.AcroFields.Fields)
        {
            if (de.Key == "Date")
            { fields.SetField("Date", dt.Rows[0]["Form Date"].ToString()); }
        
            if (de.Key == "Project Name")
            { fields.SetField("Project Name", dt.Rows[0]["Project Name"].ToString()); }
                        
            if (de.Key == "Contract No")
            { fields.SetField("Contract No", dt.Rows[0]["Contract Number"].ToString()); }
        }
        stm.Close();
        rdr.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=MyFile.pdf"); 
        //To display pdf in the browser window instead of saving, change attachment to inline
        Response.BinaryWrite(ms.ToArray());
        Response.End();
    }
