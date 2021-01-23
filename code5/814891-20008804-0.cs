    static string GetHtmlPage(string strURL)
    {
        String strResult;
        WebRequest objRequest = WebRequest.Create(strURL);
        WebResponse objResponse = objRequest.GetResponse();
        using (var sr = new StreamReader(objResponse.GetResponseStream()))
        {
            strResult = sr.ReadToEnd();
            sr.Close();
        }
        return strResult;
    }
    
    private void button3_Click(object sender, EventArgs e)
    {
        MessageBox.Show(GetHtmlPage("http://www.awardwinnersonly.com"));
    }
