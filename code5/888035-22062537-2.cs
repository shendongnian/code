    Topic topic = db.Topics.Where(a=>a.TopicID == id).FirstOrDefault();
    if(topic != null)
    {
      ViewBag.Topics = from t in db.Topics where (t.CatID == topic.CatID) select t;
    }
