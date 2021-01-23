        public static IEnumerable<ThumbnailData> GenerateThumbnails(string mediaFile, int amount, System.Drawing.Size? imagesize)
        {
            System.Drawing.Size size = imagesize ?? new System.Drawing.Size(120, 80);
            MediaPlayer player = new MediaPlayer { Volume = 0, ScrubbingEnabled = true };
            player.Open(new Uri(mediaFile));
            player.Pause();
            //We need to give MediaPlayer some time to load. 
            System.Threading.Thread.Sleep(800);
            var totalduration = player.NaturalDuration;
            if (!totalduration.HasTimeSpan)
            {
                yield break;
            }
            double avglen = totalduration.TimeSpan.TotalMilliseconds / (amount + 1d);
            for (int frameId = 0; frameId < amount; frameId++)
            {
                var timespan = avglen * (frameId + 1);
                var offset = TimeSpan.FromMilliseconds(timespan);
                player.Position = offset;
                player.Play();
                player.Pause();
                System.Threading.Thread.Sleep(400);
                RenderTargetBitmap rtb = new RenderTargetBitmap(size.Width, size.Height, 96, 96, PixelFormats.Pbgra32);
                DrawingVisual dv = new DrawingVisual();
                using (DrawingContext dc = dv.RenderOpen())
                {
                    dc.DrawVideo(player, new Rect(0, 0, size.Width, size.Height));
                }
                rtb.Render(dv);
                Duration duration = player.NaturalDuration;
                BitmapFrame frame = BitmapFrame.Create(rtb).GetCurrentValueAsFrozen() as BitmapFrame;
                BitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(frame as BitmapFrame);
                MemoryStream memoryStream = new MemoryStream();
                encoder.Save(memoryStream);
                //Here we have the thumbnail in the MemoryStream!
                memoryStream.Seek(0, SeekOrigin.Begin);
                var thumbnail = new Bitmap(memoryStream);
                yield return new ThumbnailData { Offset = offset, Image = thumbnail };
            }
            player.Close();
        }
