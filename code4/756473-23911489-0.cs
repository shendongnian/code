    using (var engine = new TesseractEngine(pathToLangFolder, "eng", EngineMode.Default))
    {
        // have to load Pix via a bitmap since Pix doesn't support loading a stream.
        using (var image = new Bitmap(fileName))
        {
            using (var pix = PixConverter.ToPix(image))
            {
                using (var page = engine.Process(pix))
                {
                    Console.WriteLine(page.GetMeanConfidence() + " : " + page.GetText());
                }
            }
        }
    }
