    public override View GetView(int position, View convertView, ViewGroup parent)
        {
            CancellationTokenSource cts;
            if (convertView == null)
            {
                // create new view
            }
            else
            {
                if (convertView.Tag != null)
                {
                    var wraper = convertView.Tag.JavaCast<Wrapper<CancellationTokenSource>>();
                    if (wraper != null)
                        wraper.Data.Cancel();
                }
            }
            ImageView imgView = convertView.FindViewById<ImageView>(Resource.Id.img_view_id);
            cts = new CancellationTokenSource();
            ResizeImageAsync(imgView, imgResId, cts.Token);
            convertView.Tag = new Wrapper<CancellationTokenSource> { Data = cts };
            return convertView; // convertView is returned before ImageView is assigned with resized image
        }
        private async Task ResizeImageAsync(ImageView imageView, int imgResId, CancellationToken ct)
        {
            Bitmap bmp = await Task<Bitmap>.Run(() => ResizeImage(imgResId, 50, 50), ct);
            if (!ct.IsCancellationRequested)
            {
                imageView.SetImageBitmap(bmp);
            }
        }
        public class Wrapper<T>: Java.Lang.Object
        {
            public T Data;
        }
