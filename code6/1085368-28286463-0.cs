    private void ProcessFile(File file, bool convertToPDF) 
    {
        Images imageRec = this.CreateNew<Images>();
        imageRec.Description = file.Name;
        imageRec.AsOfDate = System.DateTime.Now;
        // Initialize more fields to values that are common to 
        // PDF conversion files and regular files
        using (System.IO.Stream fileStream = file.OpenRead()) {
            byte[] fileBytes = new byte[System.Convert.ToInt32(fileStream.Length)];
            fileStream.Read(fileBytes, 0, fileBytes.Length);
            if (convertToPDF && (ext.ToUpper() == "TIF" || ext.ToUpper() == "TIFF")) 
            {
                imageRec.Extension = "pdf";
                // some more inits and stuff here too.
                ImagingUtilities.ConvertImgToPDF(tiffFileBytes, imageRec);
                return;
            }
            this.SaveAndAddImage(imageRec, fileBytes, file.Name);
        }
    }
