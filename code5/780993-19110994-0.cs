    public class SaveEvent : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Saving += ContentService_Saving;
        }
        void ContentService_Saving(IContentService sender, SaveEventArgs<IContent> e)
        {
            foreach (var item in e.SavedEntities)
            {
                if (!item.HasProperty("publishedCount"))
                    return;
                
                int workingCount = item.GetValue<int>("publishedCount");                              
                item.SetValue("publishedCount", workingCount++);
                if(workingCount => 1)
                {
                    // do additional work here
                }
           }
        }
    }
