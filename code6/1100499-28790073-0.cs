        private bool flag = false;
        
        private void CheckCompletion()
        {
            // Do stuff
            ConvertFiles();
            while (!flag)
                Application.DoEvents();
            // Do more stuff
        }
        private void ConvertFiles()
        {
            UpdateStatus("Converting...", true);
            Task.Factory.StartNew(() =>
            {
                using (Engine engine = new Engine())
                {
                    for (int i = 0; i < entries.Count; i++)
                    {
                        MediaFile inputFile = new MediaFile(entries[i].FilePath);
                        MediaFile outputFile = new MediaFile(entries[i].FilePath.Replace(".aac", ".mp3"));
                        engine.ConvertProgressEvent += (obj, args) =>
                        {
                            int value = (int)Math.Round(args.ProcessedDuration.TotalSeconds /
                                args.TotalDuration.TotalSeconds);
                            Invoke(new Action(delegate { entries[i].ProgressBarEx.Value = value; }));
                        };
                        engine.Convert(inputFile, outputFile);
                    }
                }
                flag = true;
            });
        }
