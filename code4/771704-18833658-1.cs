    Dictionary<int, KeyValuePair<string, string>> GetFileProps(string path)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(path);
        var dictionary = new Dictionary<int, KeyValuePair<string, string>>();
        dictionary.Add(1, new KeyValuePair<string, string>("Width", image.Width.ToString()));
        dictionary.Add(2, new KeyValuePair<string, string>("Height", image.Height.ToString()));
        
        //Implement the rest of the properties you deem important here.
        return dictionary;
    }
