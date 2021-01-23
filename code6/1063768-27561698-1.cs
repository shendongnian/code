    private static MediaTypeHeaderValue GetMimeNameFromExt(string ext)
    {
        return MimeNames
            .Where(m => m.Ext.Equals(ext, StringComparison.InvariantCultureIgnoreCase))
            .DefaultIfEmpty(new MediaTypeHeaderValue(MediaTypeNames.Application.Octet))
            .First();
    }
