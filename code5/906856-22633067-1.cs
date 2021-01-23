    var breadCrumbs = 
        EnumerateBreadCrumbs(@"http://site/org/content/Change/Book/process/item")
        .Select(uri => uri.ToString())
        .ToArray();
    
    private IEnumerable<Uri> EnumerateBreadCrumbs(string url)
    {
        var raw = new Uri(url);
        var buffer = new UriBuilder(raw.Scheme, raw.Host, raw.Port);
        yield return buffer.Uri;
        for (var i = 1; i < raw.Segements.Length; i++)
        {
            if (raw.Segments[i] == "/")
            {
                continue;
            }
            
            buffer.Path += raw.Segments[i];
            yield return buffer.Uri;
        }
        if (raw.Query.Length > 1)
        {
            buffer.Query = new string(raw.Query.Skip(1).ToArray());
            yield return buffer.Uri;
        }
        if (raw.Fragment.Length < 2)
        {
            yield break;
        }
        
        buffer.Fragment = new string(raw.Fragment.Skip(1).ToArray());
        yield return buffer.Uri;
    }
