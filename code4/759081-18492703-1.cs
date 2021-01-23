    private WebBrowser wb;
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		if (wb == null) {
			wb = new WebBrowser();
			wb.DocumentCompleted += wb_DocumentCompleted;
		}
		wb.Navigate("YourPath");
	}
	private void wb_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
	{
		IO.File.WriteAllText(IO.Path.Combine(Application.StartupPath, "Test.html"), wb.Document.Body.Parent.OuterHtml, System.Text.Encoding.GetEncoding(wb.Document.Encoding));
	}
 
