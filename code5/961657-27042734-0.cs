    System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.SaveFlag;
    System.Drawing.Imaging.Encoder compressionEncoder = System.Drawing.Imaging.Encoder.Compression;
    
    EncoderParameters encoderParameters = new EncoderParameters(2);
    encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
    encoderParameters.Param[1] =  new EncoderParameter(compressionEncoder, (long)EncoderValue.CompressionLZW);
