    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace ffmpeg_test
    {
      class Program
      {
        static readonly string exe = @"E:\ffmpeg-zeranoe\bin\ffmpeg.exe";
        static readonly string invid = @"E:\in.avi";
        static readonly string outvid = @"E:\out.avi";
    
        static void Main(string[] args)
        {
          using (var proc = new Process()) {
            Console.WriteLine("Current Directory: {0}", Directory.GetCurrentDirectory());
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = exe;
            proc.StartInfo.WorkingDirectory = new FileInfo(invid).Directory.FullName;
            Console.WriteLine("Working Directory: {0}", proc.StartInfo.WorkingDirectory);
            proc.StartInfo.Arguments = string.Format(
              "-y -i \"{0}\" -vf \"movie=watermark.png [watermark]; [in][watermark] overlay=10:10 [out]\" {1}",
              invid, outvid);
            Console.WriteLine("Arguments: {0}", proc.StartInfo.Arguments);
            proc.StartInfo.LoadUserProfile = false;
            proc.Start();
            proc.WaitForExit();
            Console.WriteLine("Result: {0}", proc.ExitCode);
          }
        }
      }
    }
