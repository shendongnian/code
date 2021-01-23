    public Result decode(Uri uri)
    {
             Bitmap image;
             try
             {
                image = (Bitmap) Bitmap.FromFile(uri.LocalPath);
             }
             catch (Exception)
             {
                throw new FileNotFoundException("Resource not found: " + uri);
             }
    
             using (image)
             {
                LuminanceSource source;
                source = new BitmapLuminanceSource(image);
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                Result result = new MultiFormatReader().decode(bitmap, hints);
                if (result != null)
                {
                    ... code found
                }
                else
                {
                    ... no code found
                }
                return result;
             }
    }
