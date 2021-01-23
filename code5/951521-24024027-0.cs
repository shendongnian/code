    // 1. Convert the image to HSV
    using (Image<Hsv, byte> hsv = original.Convert<Hsv, byte>())
    {
        // 2. Obtain the 3 channels (hue, saturation and value) that compose the HSV image
        Image<Gray, byte>[] channels = hsv.Split(); 
        try
        {
            // 3. Remove all pixels from the hue channel that are not in the range [40, 60]
            CvInvoke.cvInRangeS(channels[0], new Gray(40).MCvScalar, new Gray(60).MCvScalar, channels[0]);
            // 4. Display the result
            imageBox1.Image = channels[0];
        }
        finally
        {
            channels[1].Dispose();
            channels[2].Dispose();
        }
    }
