    public class DownloadImageTask : AsyncTask
    {
        private ImageView bmImage;
        private ProgressBar progressBar;
        public DownloadImageTask( ImageView bmImage , ProgressBar progressBar)
        {
            this.bmImage = bmImage;
            this.progressBar = progressBar;
        }
        protected override void OnPostExecute( Object result )
        {
            base.OnPostExecute(result);
            bmImage.SetImageBitmap(( Bitmap ) result);
            if (progressBar != null)
                progressBar.Visibility = ViewStates.Gone;
        }
        protected override Object DoInBackground( params Object[] @params )
        {
            var urldisplay = @params[0].ToString();
            Bitmap mIcon11 = null;
            try
            {
                var req = WebRequest.Create(urldisplay);
                var response = req.GetResponse();
                var stream = response.GetResponseStream();
                mIcon11 = BitmapFactory.DecodeStream(stream);
            }
            catch ( Exception e )
            {
            }
            return mIcon11;
        }
    }
