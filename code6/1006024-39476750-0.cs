         //Startup the raster codecs instance for loading and saving the image
         using (RasterCodecs codecs = new RasterCodecs())
         {
            //load the file using raster codecs
            using (RasterImage img = codecs.Load(inputFilename))
            {
               //Run the image processing sequence starting by resizing the image
               double newWidth = (img.Width / (double)img.XResolution) * 300;
               double newHeight = ((double)img.Height / (double)img.YResolution) * 300;
               SizeCommand sizeCommand = new SizeCommand((int)newWidth, (int)newHeight, RasterSizeFlags.Resample);
               sizeCommand.Run(img);
               AutoBinarizeCommand autoBinarize = new AutoBinarizeCommand();
               autoBinarize.Run(img);
               ColorResolutionCommand colorResolution = new ColorResolutionCommand();
               colorResolution.BitsPerPixel = 1;
               colorResolution.Run(img);
               //Save out the processed image
               codecs.Save(img, outputFilename, RasterImageFormat.Png, 1);
               //run the OCR process on the processed image and extract the text
               using (IOcrEngine ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.Advantage, false))
               {
                  ocrEngine.Startup(null, null, null, null);
                  using (IOcrPage ocrPage = ocrEngine.CreatePage(img, OcrImageSharingMode.AutoDispose))
                  {
                     ocrPage.Recognize(null);
                     Console.WriteLine(ocrPage.GetText(-1));
                     Console.ReadLine();
                  }
               }
            }
         }
