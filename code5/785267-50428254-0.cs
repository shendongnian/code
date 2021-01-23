While the op's answer works, I found the resulting string not so well formed (I really didn't like that Environment.NewLine), so for anyone out there still trying to figure out this, the following piece of code will do the trick for any amount of postData parameters, even if some of those parameters are arrays or lists, :
    string[] str = { "abc" ,  "sdfsdf" }
    var postData = new Dictionary<string, object>()
    {
        { "keyword", "monkey" },
        { "messages", str}
    };
    // Serialize the postData dictionary into a string
    string serializedPostData = string.Empty;
    foreach (KeyValuePair<string, object> pair in postData)
    {
        if (IsCollection(pair.Value))
        {
            foreach (object item in (IEnumerable)pair.Value)
            {
                //%5B%5D is encoding for []
                serializedPostData += Uri.EscapeDataString(pair.Key) + "%5B%5D=" + Uri.EscapeDataString(Convert.ToString(item)) + "&";
            }
        }
        else if (IsDate(pair.Value))
        {
            serializedPostData += Uri.EscapeDataString(pair.Key) + "=" +
                                    Uri.EscapeDataString(((DateTime)pair.Value).ToString("o")) + "&";
        }
        else
        {
            serializedPostData += Uri.EscapeDataString(pair.Key) + "=" +
                                    Uri.EscapeDataString(Convert.ToString(pair.Value)) + "&";
        }
    }
    serializedPostData = serializedPostData.TrimEnd('&');
    byte[] data = Encoding.ASCII.GetBytes(serializedPostData);
