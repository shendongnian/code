    foreach (var line in lines)
    {
        Uri uri;
        if (Uri.TryCreate(line, UriKind.Absolute, out uri))
        {
            var escaped = uri.GetComponents(UriComponents.AbsoluteUri, UriFormat.UriEscaped);
            Console.WriteLine(escaped);
            System.IO.File.AppendAllText(enpath, escaped + Environment.NewLine, Encoding.ASCII);
        }
    }
