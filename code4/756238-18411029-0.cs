    string s = webClient.DownloadString("http://www.ebay.com");
    string fixedString = s.Replace("\n", "\r\n");
    System.IO.File.WriteAllText("filename", fixedString);
    MessageBox.Show(fixedString, "Source code",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
