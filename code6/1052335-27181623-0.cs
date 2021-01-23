    string result = new StreamReader(request.InputStream).ReadToEnd();
    if (!string.IsNullOrWhiteSpace(result)) {
        var items = JsonConvert.DeserializeObject<RootObject>(result);
        string paymentID = items.entry.FirstorDefault().id;
    }
