    protected void ibtDownloadImage_OnClick(object sender, EventArgs e)
    {
       ImageButton img = (ImageButton)sender;
       String imgURLtoDownload = sender.CommandArgument; 
       Response.TransmitFile(imgURLtoDownload);
    }
