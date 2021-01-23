    public static async Task<StorageFile> SaveToFile(
        this WriteableBitmap writeableBitmap,
        StorageFolder storageFolder,
        string fileName,
        CreationCollisionOption options = CreationCollisionOption.ReplaceExisting)
    {
        StorageFile outputFile =
            await storageFolder.CreateFileAsync(
                fileName,
                options);
        Guid encoderId;
        var ext = Path.GetExtension(fileName);
        if (new[] { ".bmp", ".dib" }.Contains(ext))
        {
            encoderId = BitmapEncoder.BmpEncoderId;
        }
        else if (new[] { ".tiff", ".tif" }.Contains(ext))
        {
            encoderId = BitmapEncoder.TiffEncoderId;
        }
        else if (new[] { ".gif" }.Contains(ext))
        {
            encoderId = BitmapEncoder.GifEncoderId;
        }
        else if (new[] { ".jpg", ".jpeg", ".jpe", ".jfif", ".jif" }.Contains(ext))
        {
            encoderId = BitmapEncoder.JpegEncoderId;
        }
        else if (new[] { ".hdp", ".jxr", ".wdp" }.Contains(ext))
        {
            encoderId = BitmapEncoder.JpegXREncoderId;
        }
        else //if (new [] {".png"}.Contains(ext))
        {
            encoderId = BitmapEncoder.PngEncoderId;
        }
        await writeableBitmap.SaveToFile(outputFile, encoderId);
        return outputFile;
    }
