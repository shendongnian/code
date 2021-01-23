    using System.Net;
    using System.IO;
    using System.Text.RegularExpressions;
    private void Form1_Load(object sender, EventArgs e)
    {
        string urlAddress = "http://melloniax.com/css/style.css";
        string urlBase = "http://melloniax.com";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string data = "";
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;
            if (response.CharacterSet == null)
                readStream = new StreamReader(receiveStream);
            else
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            data = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
        }
        MatchCollection matches = Regex.Matches(data, @"\(..(?<link>[^.]*(\.jpg|\.png|\.gif)) *\)");
        for (int a = 0; a < matches.Count; a++)
            MessageBox.Show(urlBase + matches[a].Groups["link"].Value);
    }
