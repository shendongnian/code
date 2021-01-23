    namespace MyCustom.Media
    {
      public class MediaProvider : Sitecore.Resources.Media.MediaProvider
      {
        public override string GetMediaUrl(MediaItem item)
        {
          Assert.ArgumentNotNull((object) item, "item");
          return this.GetMediaUrl(item, MediaUrlOptions.Empty);
        }
        public override string GetMediaUrl(MediaItem item, MediaUrlOptions options)
        {
          options.AllowStretch = true;
          return base.GetMediaUrl(item, options);
        }
    }
