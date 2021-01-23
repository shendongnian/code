    string Url = "";
    Url = "http://xxxxxxxxxxxxxx/AttributesHandler.ashx?cd=xx";
    object @out = null;
    try {
	Net.WebClient webclient = new Net.WebClient();
	webclient.UseDefaultCredentials = true;
	@out = System.Text.Encoding.ASCII.GetString((webclient.DownloadData(Url)));
    } catch (Exception ex) {
	//out = ex.InnerException.ToString
    }
