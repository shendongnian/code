    namespace MyCustom.Media
    {
      public class MediaProvider : Sitecore.Resources.Media.MediaProvider
      {
        public override string GetMediaUrl(MediaItem item)
        {
          Assert.ArgumentNotNull((object) item, "item");
          var options = new MediaUrlOptions();
          options.AllowStretch = true;
          return base.GetMediaUrl(item, options);
        }
      }
    }
