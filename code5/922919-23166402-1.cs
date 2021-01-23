    public ActionResult Topic(int id) //Topic Id
    {
        Topic topic = null; // topic is your POCO
        using (var db = new DataContext())
        {
            topic = db.Topics.Include("Messages").Include("Messages.CreatedBy").Include("CreatedBy").FirstOrDefault(x => x.Id == id);   
        }
        return topic != null ? View(topic) : View();
    }
