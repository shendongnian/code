    using (MemoryStream stream = new MemoryStream())
    {
            Chart1.SaveImage(stream, ChartImageFormat.Png);
            iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
            chartImage.ScalePercent(75f);
            pdfDoc.Add(chartImage);
            pdfDoc.Close();
        
            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment;filename=Chart.pdf");
            Response.ContentType = "application/pdf";
            Response.WriteFile(pdfDoc);
            Response.Flush();
            Response.End();
    } 
