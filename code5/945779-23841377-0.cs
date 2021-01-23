    public ActionResult General(int id)
        {
            List<Topics> topics = new List<Topics>();
            Topics top = new Topics();
            List<string> items = new List<string>();
            topics = top.getAllTopics(id);
            for (int i = 0; i < topics.Count; i++)
            {
    
                items.Add(topics[i].name);
    
            }
            ViewBag.Items = items;
            ViewBag.Counter = topics.Count; // this line was added
            return View(topics.Count);
        }
