    // Check if the TopMargin band is already present in the report. 
    if(Bands.GetBandByType(typeof(ReportHeaderBand)) == null) {
        // Create a new TopMargin band and add it to the report. 
        ReportHeaderBandtmBand = new ReportHeaderBand();
        Bands.Add(tmBand);
    
        // Create a picture object
        XRPictureBox picBox = new XRPictureBox();
        picBox.Visible = true;
        picBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
        picBox.Image = Resources.Logo;
        this.Controls.Add(picBox);
    
        // Add the label to the ReportHeaderBand band. 
        tmBand.Controls.Add(picBox);
    }
