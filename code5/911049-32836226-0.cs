       img = (Bitmap)eventArgs.Frame.Clone();
       for (int i = 0; i < 1000; i++)
            {
                writer.WriteVideoFrame(img);
            }
