    protected void Button1_Click(object sender, EventArgs e)
    {
        using (var request = WebRequest.Create("http://foreignserver/api/..."))
        using (var response = request.GetResponse())
        using (var reader = new StreamReader(response.GetResponseStream())
        {
            string y = reader.ReadToEnd();
            ...
        }
    }
