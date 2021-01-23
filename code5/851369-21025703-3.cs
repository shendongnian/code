    public ActionResult Index()
    {
        myEntities db = new myEntities();
        List<MeetingModel> models = db.meetings.Select(i =>
            new MeetingModel {
                Title = i.title,
                Address = i.address,
                Date = i.event_date_time,
                Description = i.description,
                OrganizerName = i.users.SingleOrDefault(u => u.id == i.organizer_id).name
            }).ToList();
        return View(models);
    }
