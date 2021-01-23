    var listOfDistinctUrls = File.ReadLines(@"PathToTextFile");
        .Where(l => !string.IsNullOrWhiteSpace(l))
        .Select(l => {
            string token = l.Split().Last();
            Uri uri;
            if (Uri.TryCreate(token, UriKind.RelativeOrAbsolute, out uri))
            {
                string fileName = Path.GetFileName(uri.IsAbsoluteUri ? uri.Host + uri.PathAndQuery : uri.ToString());
                int wwwIndex = fileName.IndexOf("www.", 0, StringComparison.OrdinalIgnoreCase);
                return wwwIndex >= 0 ? fileName.Substring(wwwIndex + 4) : fileName;
            }
            else
                return null;
        })
        .Where(u => !string.IsNullOrWhiteSpace(u))
        .Distinct()
        .ToList();
