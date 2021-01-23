    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
        // open the file to read its contents
        if ((myStream = saveFileDialog1.OpenFile()) != null)
        {
            // create NEW PDF object in memory
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    
            // use memory stream for image
            using (MemoryStream stream = new MemoryStream())
            {
                // open pdf for changes
                pdfDoc.Open();
                // write image to memory stream
                pieChart.SaveImage(stream, ChartImageFormat.Png);
                // create image instance from memory stream
                iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                chartImage.ScalePercent(75f);
                // add the image to pdf document
                pdfDoc.Add(chartImage);
            }
            // close document... and forget about it. all changes were made in memory
            // pdfDoc will be collected by GC.
            pdfDoc.Close();
            // try to create new file with the name as already opened by myStream - Exception here
            using (FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.Create, System.IO.FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] bytes = new byte[myStream.Length];
                myStream.Read(bytes, 0, (int)myStream.Length);
                file.Write(bytes, 0, bytes.Length);
                myStream.Close();
            }
        }
    }
