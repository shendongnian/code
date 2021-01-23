        while (true)
        {
            Thread.Sleep(5);
            using (var bitmap = new GDI.Bitmap(1000, 1000))
            {
                var hbitmap = bitmap.GetHbitmap();
                var image = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                image.Freeze();
              DeleteObject(hbitmap);
            }
            Console.WriteLine("Current memory consumption" + GC.GetTotalMemory(false));
            GC.Collect(3);
        }
