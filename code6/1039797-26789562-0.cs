    var index = ContentSearchManager.GetIndex((SitecoreIndexableItem)ItemReferences.RootItem);
            var sitecoreService = new SitecoreService(Sitecore.Context.Database.Name);
            using (var context = index.CreateSearchContext())
            {
                var result = context.GetQueryable<Insights>()
                    .FirstOrDefault(item => item.ItemId == insights.ItemId);
                sitecoreService.Map(result);
                return result;
            }
