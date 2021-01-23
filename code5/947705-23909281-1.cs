    private async Task<RenderTargetBitmap> CreateBitmapFromElement(FrameworkElement uielement)
    {
        try
        {
            var renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(uielement);
            return renderTargetBitmap;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        return null;
    }
