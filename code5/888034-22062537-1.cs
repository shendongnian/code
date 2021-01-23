    ViewBag.Topics = "";
    ViewBag.BreadCrumb = "";
    ViewBag.TopicID = id;
    Topic topic = db.Topics.Where(a=>a.TopicID == id && a.CatID == topic.CatID).FirstOrDefault();
    if(topic != null)
    {
      ViewBag.Topics = topic;
      ViewBag.BreadCrumb = topic.Category.CatName + " / " + topic.Name;
    }
