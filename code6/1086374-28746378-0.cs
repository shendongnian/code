    using System;
    using System.IO;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Resources.Media;
    namespace YourNamespace
    {
    public partial class MediaLibraryExporter : System.Web.UI.Page
    {
        public void ExportMedia(object sender, EventArgs e)
        {
            var database = Database.GetDatabase("master");
            var images = database.SelectItems("/sitecore/media library/Images/Branches/descendant::*[@@templatekey='jpeg']");
            foreach (var image in images)
            {
                var mediaItem = (MediaItem)image;
                var media = MediaManager.GetMedia(mediaItem);
                var stream = media.GetStream();
                using (var targetStream = File.OpenWrite(Path.Combine("Your output folder location", image.Name + ".jpeg" )))
                {
                    stream.CopyTo(targetStream);
                    targetStream.Flush();
                }
            }
        }
    }
}
