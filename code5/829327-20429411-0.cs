    this.BackgroundImage = await GetImageAsync("http://......");
---
    async Task<Image> GetImageAsync(string url)
    {
        using (var client = new HttpClient())
        {
            var bmp = (Bitmap)Bitmap.FromStream(await client.GetStreamAsync(url));
            Color transparent = Color.FromArgb(255, 255, 250, 238);
            bmp.MakeTransparent(transparent);
            return bmp;
        }
    }
