    using System;
    using AForge.Video.FFMPEG;
    
    namespace TEF
    {
        static class Program
        {
            private static void Main()
            {
    
                var reader = new VideoFileReader();
    
                reader.Open(@"your video here");
    
                // video attributes
                Console.WriteLine("width:  " + reader.Width);
                Console.WriteLine("height: " + reader.Height);
                Console.WriteLine("fps:    " + reader.FrameRate);
                Console.WriteLine("codec:  " + reader.CodecName);
    
                // read video frames
                while (true)
                    using (var videoFrame = reader.ReadVideoFrame())
                    {
                        if (videoFrame == null)
                            break;
    
                        // process the frame here
                    }
    
                reader.Close();
            }
        }
    }
