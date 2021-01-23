    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            WritableBitmap bitmap = new WriteableBitmap((int)e.Frame.Width, (int)e.Frame.Height); //crash here
            await bitmap.SetSourceAsync(e.Frame);
    
            OcrResult result = await ocr.RecognizeAsync(e.Frame.Height, e.Frame.Width, bitmap.PixelBuffer.ToArray());
    
            foreach (var line in result.Lines)
            {
    
            }
        });
