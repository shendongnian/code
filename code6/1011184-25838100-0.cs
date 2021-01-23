    using (var session = NHibernateHelper.OpenSession())
    {
      Feed feed = new Feed();
    
      Tag tag = Tag.READ.ById(8);
      feed.Tag.Add(tag);
      feed.Language = ENLanguage.EN;
      feed.Name = "Foo";
    
      feed.Save();
    
      string x = JsonConvert.SerializeObject(feed);
    }
