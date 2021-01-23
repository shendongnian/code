    private static readonly Regex _regexEncodedFileName = new Regex(@"^=\?utf-8\?B\?([a-zA-Z0-9/+]+={0,2})\?=$");
    
    private static string TryToGetOriginalFileName(string fileNameInput) {
        Match match = _regexEncodedFileName.Match(fileNameInput);
        if (match.Success && match.Groups.Count > 1) {
            string base64 = match.Groups[1].Value;
            try {
                byte[] data = Convert.FromBase64String(base64);
                return Encoding.UTF8.GetString(data);
            }
            catch (Exception) {
                //ignored
                return fileNameInput;
            }
        }
        return fileNameInput;
    }
