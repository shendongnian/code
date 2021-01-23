    // Called after the document has been rendered
    private void DiagnosticsWebBrowser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            // Resize the window
            int width = WebBrowser.Document.Body.ScrollRectangle.Size.Width;
            width = Math.Min(width, (int)SystemParameters.WorkArea.Width - 100);
            
            int height = WebBrowser.Document.Body.ScrollRectangle.Size.Height;
            height = Math.Min(height, (int)SystemParameters.WorkArea.Height - 100);
            DiagnosticsWebBrowser.Size = new System.Drawing.Size(width, height);
            UpdateLayout();
            // Re-center the window
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = (SystemParameters.WorkArea.Width - ActualWidth) / 2 + SystemParameters.WorkArea.Left;
            Top = (SystemParameters.WorkArea.Height - ActualHeight) / 2 + SystemParameters.WorkArea.Top;
        }
