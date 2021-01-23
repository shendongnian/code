    public ActionResult Index()
    {
        HeadVM list = new HeadVM()
            {
                data = new List<Heads>()
            };
            var AllHeads = context.Heads;
            foreach (var item in AllHeads)
            {
                if (item != null)
                {
                    list.data.Add(new Heads
                    {
                        h_id = item.h_id,
                        fname = item.fname,
                        lname = item.lname,
                    });
                }
            }
            return View(list);
    }
