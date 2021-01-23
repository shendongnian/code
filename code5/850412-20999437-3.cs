    byte[] base64Bytes = await mixedContent.ReadAsByteArrayAsync();
    string base64String = System.Text.Encoding.Default.GetString(base64Bytes);
    byte[] imageBytes = Convert.FromBase64String(base64String);
    using (var ms = new MemoryStream(imageBytes))
    {
        img = Image.FromStream(ms);
    }
