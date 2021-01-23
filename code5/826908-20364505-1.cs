    public class HomeModule : NancyModule
    {
        public HomeModule(MyXmlCache xmlCache)
        {
             Get["/"] => xmlCache;
        }
      }
