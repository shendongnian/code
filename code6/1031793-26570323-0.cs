    public dynamic Post(List<CellModel> cells)
    {
        string content = string.Empty;
        if (HttpContext.Current.Request.InputStream.CanSeek)
        {
            HttpContext.Current.Request.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
        }
        using (System.IO.StreamReader reader = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
        {
            content = reader.ReadToEnd();
        }
        if (!string.IsNullOrEmpty(content))
        {
            // Deserialize and operate over cells.
        }
        return cells; // return whatever required 
    }
