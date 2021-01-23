     var result = from eventCat in EventCategory
                  select new
                  {
                    Key = eventCat.Key,
                    EventValue = eventCat.Value,
                    ReadingValue = ReadingCategory.Where(x => x.Key.Equals(eventCat.Key)).Select(x => x.Value).First(),
                    EventPercentage = eventCat.Value / (double)EventCategory.Sum(x => x.Value),
                    ReadingPercentage = ReadingCategory.Where(x => x.Key.Equals(eventCat.Key)).Select(x => x.Value).First() / (double)ReadingCategory.Sum(x => x.Value),
                    TotalPercentage = (eventCat.Value / (double)EventCategory.Sum(x => x.Value) +
                    ReadingCategory.Where(x => x.Key.Equals(eventCat.Key)).Select(x => x.Value).First() / (double)ReadingCategory.Sum(x => x.Value)) / 2
                  };
