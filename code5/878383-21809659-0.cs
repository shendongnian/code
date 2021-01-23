    private void GetItems(int month, int year)
            {
                DateTime startDate = new DateTime(year,month,1);
                DateTime endDate = new DateTime(year,month, DateTime.DaysInMonth(year, month));
                using ( IProviderSearchContext context = ContentSearchManager.GetIndex("sitecore_master_index").CreateSearchContext())
                {
                    List<EventSearchResultItem> allEvents = context.GetQueryable<EventSearchResultItem>(new CultureExecutionContext(Sitecore.Context.Language.CultureInfo))
                    .Where(s =>
                           s.TemplateId == this.EventTemplateID &&
                           ((s.BeginDate >= startDate) || (s.EndDate <= endDate))
                               )
                   .ToList();
                }
            }
