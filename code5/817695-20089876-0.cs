    private void OpenPdf(string filePath)
    {
        if (!string.IsNullOrWhiteSpace(filePath))
        {
            webBrowser1.Navigate(@filePath);
        }
    }
Call the method within button click
    private void button1_Click(object sender, EventArgs e)
    {
        OpenPdf(@"C:\Users\kkk\Downloads\DEF2236.pdf");
    }
