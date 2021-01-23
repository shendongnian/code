    [...]
    using Gadgeteer.Networking;
    [...]
        var request = HttpHelper.CreateHttpGetRequest(_GetCurrentDemoURL + _ID);
        request.ResponseReceived += GetDataResponseReceived;
        request.SendRequest();
    [...]
    private void GetDataResponseReceived(HttpRequest sender, HttpResponse response)
    {
        Debug.Print(response.StatusCode + ": " + response.Text);
        if (response.StatusCode == "200")
        {
            DataReceived(response.Text);
        }
    }
