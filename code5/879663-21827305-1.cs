    void printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (printDocument.PrintController.IsPreview)
        {
            Image image = Image.FromFile("ScannedImagePath");
            e.Graphics.DrawImage(image,0,0)
        }
        // print other text here after drawing the background
    }           
