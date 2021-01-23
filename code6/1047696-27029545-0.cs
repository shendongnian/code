    IAsyncOperation<BitmapEncoder> CreateEncoderWithEncodingOptionsAsync(
        Windows.Storage.Streams.IRandomAccessStream stream
        )
    {
        var propertySet = new Windows.Graphics.Imaging.BitmapPropertySet();
        var qualityValue = new Windows.Graphics.Imaging.BitmapTypedValue(
            1.0, // Maximum quality
            Windows.Foundation.PropertyType.Single
            );
    
        propertySet.Add("ImageQuality", qualityValue);
        return Windows.Graphics.Imaging.BitmapEncoder.CreateAsync(
            Windows.Graphics.Imaging.BitmapEncoder.JpegEncoderId,
            stream,
            propertySet
            );
    
        // Encoder is initialized with encoding options.
    }
