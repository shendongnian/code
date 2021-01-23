    GetLines(string path, ()=>
    {
        // here your code...
    });
    public void GetLines(string _path, Action<string> callback)
    {
        var result = string.Empty;
        new Action(() =>
        {
            var encoding = new UnicodeEncoding();
            byte[] allText;
            using (FileStream stream = File.Open(_path, FileMode.Open))
            {
                allText = new byte[stream.Length];
                //something like this, but does not compile in .net 3.5
                stream.Read(allText, 0, (int)allText.Length);
            }
            result = encoding.GetString(allText);
        }).BeginInvoke(x => callback(result), null);
    }
