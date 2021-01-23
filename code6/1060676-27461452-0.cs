    public string Decode(WriteableBitmap sImage)
    {
        var br = new BarcodeReader();
        var result = br.Decode(sImage);
        if (result != null)
        {
            return result.Text;
        }
        return null;
    }
