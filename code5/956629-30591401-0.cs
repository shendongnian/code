    using (VideoFrameReader videoFrameReader = new VideoFrameReader(newCreatedVideo))
            {
                await videoFrameReader.OpenMF();
                var image = videoFrameReader.GetFrameAsBitmap(TimeSpan.FromSeconds(0));
                videoFrameReader.Finalize();
            }
