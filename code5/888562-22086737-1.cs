    namespace MyCustom.Media
    {
      public class MediaProvider : Sitecore.Resources.Media.MediaProvider
      {
        public override string GetMediaUrl(MediaItem item, MediaUrlOptions options)
        {
          options.AllowStretch = true;
          return base.GetMediaUrl(item, options);
        }
    }
