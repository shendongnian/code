        public class KeyphraseEvents : ApplicationEventHandler
        {
            private KeyphraseApiController _keyphraseApiController;
            protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, 
                                               ApplicationContext applicationContext)
            {
                _keyphraseApiController = new KeyphraseApiController();
                ContentService.Saving += ContentServiceOnSaving;
                var db = applicationContext.DatabaseContext.Database;
                if (!db.TableExist("keyphrase"))
                {
                    db.CreateTable<Keyphrase>(false);
                }
            }
            private void ContentServiceOnSaving(IContentService sender, SaveEventArgs<IContent> saveEventArgs)
            {
                var keyphrases = _keyphraseApiController.GetAll();
                var keyphraseContentParser = new KeyphraseContentParser();
                foreach (IContent content in saveEventArgs.SavedEntities)
                {
                    if (content.ContentType.Alias.Equals("NewsArticle"))
                    {
                        var blogContent = content.GetValue<string>("bodyContent");
                        var parsedBodyText = keyphraseContentParser.ReplaceKeyphrasesWithLinks(blogContent, keyphrases);
                        content.SetValue("bodyContent", parsedBodyText);
                    }
                }
            }
        }
