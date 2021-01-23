            List<string> applicableReports = CurrentWizard.GetApplicableReports();
            previousReportsStream = new MemoryStream();
      
    
            try
            {
        
                for (int i = 0; i < streams.Length; i++)
                {
                    using( MemoryStream memStream = new MemoryStream(DocumentHelper.Instance.ConvertFileToByteArray(applicableReports[i]))
                    {
                    memStream.CopyTo(previousReportsStream);
                    }
                }
        
                RadPdfViewer radPdfViewer = new RadPdfViewer();
                RadFixedDocument document = new PdfFormatProvider(previousReportsStream, FormatProviderSettings.ReadAllAtOnce).Import();
                radPdfViewer.Document = document;
           }
           finally
           {
              previousReportsStream.Close();
           }
