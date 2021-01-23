        public static void AviMovie(FileInfo[] FileNames)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(FileNames[0].FullName);
            AviManager aviManager =
                new AviManager(@"c:\temp\new.avi", false);
            VideoStream aviStream =
                aviManager.AddVideoStream(false, 25, bitmap);
            int count = 0;
            for (int n = 0; n < FileNames.Length; n++)
            {
                if (FileNames[n].Length > 0)
                {
                    bitmap =
                       (Bitmap)Bitmap.FromFile(FileNames[n].FullName);
                    aviStream.AddFrame(bitmap);
                    bitmap.Dispose();
                    int pctDone = (n+1) * 100 / FileNames.Length;
                    backgroundWorker1.ReportProgress(pctDone);
                }
            }
            aviManager.Close();
        }
