    public class TweetModel
    {
        public string Username { get; set; }
        public string Timestamp { get; set; }
        public string Message { get; set; }
        public string Link { get; set;  }
        public TweetModel(Status status)
        {
            Timestamp = ToAgo(status);
            Username = status.User.ScreenNameResponse;
            Message = FormatTweet(status);
        }
        public static string ToAgo(Status status)
         {
             DateTime date1 = DateTime.Now;
             DateTime date2 = status.CreatedAt;
             if (DateTime.Compare(date1, date2) >= 0)
             {
                 TimeSpan ts = date1.Subtract(date2);
                 if (ts.TotalDays >= 1)
                    return string.Format("{0} dage", (int)ts.TotalDays);
                else if (ts.Hours > 2)
                    return string.Format("{0} timer", ts.Hours);
                else if (ts.Hours > 0)
                    return string.Format("{0} timer, {1} minutes", 
                           ts.Hours, ts.Minutes);
                else if (ts.Minutes > 5)
                    return string.Format("{0} minutter", ts.Minutes);
                else if (ts.Minutes > 0)
                    return string.Format("{0} minutter, {1} sekunder", 
                           ts.Minutes, ts.Seconds);
                else
                    return string.Format("{0} sekunder", ts.Seconds);
            }
            else
                return "Not valid";
        }
        protected string FormatTweet(Status status)
        {
            var entities = new List<EntityBase>();
            entities.AddRange(status.Entities.HashTagEntities);
            entities.AddRange(status.Entities.UrlEntities);
            entities.AddRange(status.Entities.UserMentionEntities);
            entities = entities.OrderByDescending(item => item.Start).ToList();
            var linkedText = status.Text;
            foreach (var entity in entities)
            {
                if (entity is HashTagEntity)
                {
                    var tagEntity = (HashTagEntity)entity;
                    linkedText = string.Format(
                        "{0}<a class=\"tweetlink\" href=\"http://twitter.com/search?q=%23{1}\">#{1}</a>{2}",
                        linkedText.Substring(0, entity.Start),
                        tagEntity.Tag,
                        linkedText.Substring(entity.End));
                }
                else if (entity is UserMentionEntity)
                {
                    var mentionEntity = (UserMentionEntity)entity;
                    linkedText = string.Format(
                        "{0}<a class=\"tweetlink\" href=\"http://twitter.com/{1}\">@{1}</a>{2}",
                        linkedText.Substring(0, entity.Start),
                        mentionEntity.ScreenName,
                        linkedText.Substring(entity.End));
                }
                else if (entity is UrlEntity)
                {
                    var urlEntity = (UrlEntity)entity;
                    linkedText = string.Format(
                        "{0}<a class=\"tweetlink\" href=\"{1}\">{1}</a>{2}",
                        linkedText.Substring(0, entity.Start),
                        urlEntity.Url,
                        linkedText.Substring(entity.End));
                }
            }
            return linkedText;
        }
    }
