            string inputFile = @"in.jpg";
            string outputFile = @"out.jpg";
            Bitmap inputPhoto = new Bitmap(inputFile);
            ImageCodecInfo decoder = null;
            ImageCodecInfo[] decoders = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo c in decoders)
            {
                if (c.FormatID == ImageFormat.Jpeg.Guid)
                {
                    decoder = c;
                    break;
                }
            }
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters encoderParams = new EncoderParameters(1);
            EncoderParameter qualityParam = new EncoderParameter(encoder, 70L);
            encoderParams.Param[0] = qualityParam;
            inputPhoto.Save(outputFile, decoder, encoderParams);
