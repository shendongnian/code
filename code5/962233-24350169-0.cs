    // Get a bitmap.
    Bitmap bmp1 = new Bitmap(@"c:\TestPhoto.jpg");
    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
    // Create an Encoder object based on the GUID 
    // for the Quality parameter category.
    System.Drawing.Imaging.Encoder myEncoder =
        System.Drawing.Imaging.Encoder.Quality;
    // Create an EncoderParameters object. 
    // An EncoderParameters object has an array of EncoderParameter 
    // objects. In this case, there is only one 
    // EncoderParameter object in the array.
    EncoderParameters myEncoderParameters = new EncoderParameters(1);
    myEncoderParameter = new EncoderParameter(myEncoder, 100L);
    myEncoderParameters.Param[0] = myEncoderParameter;
    bmp1.Save(@"c:\TestPhotoQualityHundred.jpg", jgpEncoder, myEncoderParameters);
