    private void ProcessFile(File file, bool convertToPDF) 
    {
        Images imageRec = this.CreateNew<Images>();
        imageRec.Description = file.Name;
        imageRec.AsOfDate = System.DateTime.Now;
        // ...
        using (System.IO.Stream fileStream = file.OpenRead()) {
            byte[] fileBytes = new byte[System.Convert.ToInt32(fileStream.Length)];
            fileStream.Read(fileBytes, 0, fileBytes.Length);
            if (convertToPDF && (ext.ToUpper() == "TIF" || ext.ToUpper() == "TIFF")) 
            {
                // Configure imageRec fields for PDF
                imageRec.Extension = "pdf";
                // ...
                ImagingUtilities.ConvertImgToPDF(tiffFileBytes, imageRec);
            }
            else
            {
                // Configure imageRec fields for everything else
                // ...
                this.SaveAndAddImage(imageRec, fileBytes, file.Name);
            }
            
        }
    }
