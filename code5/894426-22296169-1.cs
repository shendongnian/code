using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
namespace My.Namespace
{
    public class MyEventHandler : ApplicationEventHandler
    {
        public MyEventHandler()
        {
            MediaService.Saved += MediaServiceSaved;
        }
        void MediaServiceSaved(IMediaService sender, SaveEventArgs<IMedia> e)
        {
            foreach (var mediaItem in e.SavedEntities)
            {
                // Do whatever you want with each entity
            }
        }
    }
}
