    if( (new File(imageFile.Path)).Exists() )
    {
        using (Bitmap bitmap = imageFile.Path.LoadAndResizeBitmap(width, height))
        {
            //...
        }
     }
---
    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        ImageView v = (ImageView) convertView;
        if (v == null)
        {
            LayoutInflater li = (LayoutInflater) this.Context.GetSystemService(Context.LayoutInflaterService);
            v = (ImageView) li.Inflate(Resource.Layout.GridItem_Image, null);           
        }
        File imageFile = _imageFiles[position];
        if (imageFile != null)
        {
            int width = PictureWidth;
            int height = PictureHeight;
            if( (new File(imageFile.Path)).Exists() )
            {
                using (Bitmap bitmap = imageFile.Path.LoadAndResizeBitmap(width, height))
                {
                    v.RecycleBitmap();
                    v.SetImageBitmap(bitmap);
                }
            }
        }
        return v;
    }
