    using Lumia.Imaging;
    using Lumia.InteropServices.WindowsRuntime;
    using Lumia.Imaging.Artistic;
...
    async Task FilterWriteableBitmap(WriteableBitmap wbIn, WriteableBitmap wbOut)
    {
        using (var imageSource = new BitmapImageSource(wbIn.AsBitmap()))
        using (var filterEffect = new FilterEffect(imageSource))
        using (var renderer = new WriteableBitmapRenderer(filterEffect,wbOut)) 
        {
            var filter = new SketchFilter(SketchMode.Color);
            filterEffect.Filters = new IFilter[] { filter };
            
            await renderer.RenderAsync();
        }
    }
    ...
    await FilterWriteableBitmap(originalWB,filteredWB)
    img.Source = filteredWB;
