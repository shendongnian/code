    try
            {
                txtURL.Text = Server.UrlDecode(Decrypt(url, mainKey));
                string TheUrl = txtURL.Text;
                string response = GetHtmlPage(TheUrl);
