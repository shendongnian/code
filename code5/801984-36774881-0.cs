    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    
    namespace PipeFfmpeg
    {
        class Program
        {
            public static void Video(int bitrate, int fps, string outputfilename)
            {
                Process proc = new Process();
    
                proc.StartInfo.FileName = @"ffmpeg.exe";
                proc.StartInfo.Arguments = String.Format("-f image2pipe -i pipe:.bmp -maxrate {0}k -r {1} -an -y {2}",
                    bitrate, fps, outputfilename);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
    
                proc.Start();
    
                for (int i = 0; i < 500; i++)
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var img = Image.FromFile(@"lena.png"))
                        {
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            ms.WriteTo(proc.StandardInput.BaseStream);
                        }
                    }
                }            
            }
    
            static void Main(string[] args)
            {
                Video(5000, 10, "lena.mp4");
            }
        }
    }
