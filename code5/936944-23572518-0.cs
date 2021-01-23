        // Find image view.
        var imgView = this.FindViewById<ImageView>(Resource.Id.imageView);
        // Set some image
    content.imgView.SetImageDrawable(this.Resources.GetDrawable(Resource.Drawable.Icon)); imgView.BuildDrawingCache ();
        
        // Get the bitmap content of the image view.
        Bitmap bitmap = imgView.DrawingCache;
        // Save as PNG to disk.
        string path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "image.png");
        using (var stream = File.OpenWrite(path))
        {
        	bitmap.Compress (Bitmap.CompressFormat.Png, 100, stream);
        }
        Console.WriteLine("Image saved to {0}", path);
