    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
        if ((myStream = saveFileDialog1.OpenFile()) != null)
        {
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    
            using (MemoryStream stream = new MemoryStream())
            {
                pdfDoc.Open();
                pieChart.SaveImage(stream, ChartImageFormat.Png);
                iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                chartImage.ScalePercent(75f);
                pdfDoc.Add(chartImage);
            }
            pdfDoc.Close();
            using (FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.Create, System.IO.FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] bytes = new byte[myStream.Length];
                myStream.Read(bytes, 0, (int)myStream.Length);
                file.Write(bytes, 0, bytes.Length);
                myStream.Close();
            }
        }
    }
