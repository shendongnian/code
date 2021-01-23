    private List<string> GetImageWithGhostGhostscriptProcessor(string psFilename, string outputPath, int dip = 300)
        {
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
            GhostscriptVersionInfo gv = GhostscriptVersionInfo.GetLastInstalledVersion(
                GhostscriptLicense.GPL | GhostscriptLicense.AFPL,
                GhostscriptLicense.GPL);
            using (GhostscriptProcessor processor = new GhostscriptProcessor(gv, true))
            {
                processor.Processing += new GhostscriptProcessorProcessingEventHandler(processor_Processing);
                
                List<string> switches = new List<string>();
                switches.Add("-empty");
                switches.Add("-dSAFER");
                switches.Add("-dBATCH");
                switches.Add("-dNOPAUSE");
                switches.Add("-dNOPROMPT");
                switches.Add(@"-sFONTPATH=" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts));
                switches.Add("-dFirstPage=" + 1);
                switches.Add("-dLastPage=" + 1);
                //switches.Add("-sDEVICE=png16m");
                switches.Add("-sDEVICE=tiff24nc");
                //switches.Add("-sDEVICE=pdfwrite");
                switches.Add("-r" + dip);
                switches.Add("-dTextAlphaBits=4");
                switches.Add("-dGraphicsAlphaBits=4");
                switches.Add(@"-sOutputFile=" + outputPath + "\\page-%03d.tif");
                //switches.Add(@"-sOutputFile=" + outputPath + "page-%03d.png");
                switches.Add(@"-f");
                switches.Add(psFilename);
                
                processor.StartProcessing(switches.ToArray(), null);
            }
            return Directory.EnumerateFiles(outputPath).ToList();
        }
