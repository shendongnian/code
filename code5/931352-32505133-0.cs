    private void reportViewer_Hyperlink(object sender, HyperlinkEventArgs e)
    {
        Uri uri = new Uri(e.Hyperlink);
        if (uri.Scheme.ToLower() == "copy")
        {
            System.Windows.Forms.Clipboard.SetText(uri.Authority);
            e.Cancel = true; // Load the customer details in another form
            ((ReportViewer)sender).RefreshReport();
        }
     }
