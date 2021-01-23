    using System;
    using System.Linq;
    using Umbraco.Core;
    using Umbraco.Core.Services;
    
    namespace YourNamespace
    {
        /// <summary>
        /// Updates the publishedDate property when content is first published
        /// </summary>
        public class UpdatePublishDateEventHandler : ApplicationEventHandler
        {
            protected override void ApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
            {
                ContentService.Published += ContentService_Published;
            }
    
            void ContentService_Published(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
            {
                const string publishedDateKey = "publishedDate";
                var contentService = ApplicationContext.Current.Services.ContentService;
                foreach (var content in e.PublishedEntities.Where(x => x.HasProperty(publishedDateKey)))
                {
                    var existingValue = content.GetValue(publishedDateKey);
                    if (existingValue == null)
                    {
                        content.SetValue(publishedDateKey, DateTime.Now);
                        contentService.SaveAndPublishWithStatus(content, raiseEvents: false);
                    }
                }
            }
        }
    }
