    // Index View
    @using (Html.BeginForm())
    {
        @for (var i = 0; i < Model.Count; i++)
        {
            <div>
                @Html.HiddenFor(model => Model[i].ActivityId)
                @Html.EditorFor(model => Model[i].Duration)
                @Html.EditorFor(model => Model[i].Date)
            </div>
        }
        <input type="submit" value="LOG TIME ENTRIES" />
    }
    // Controller Post Method
    [HttpPost]
    public ActionResult Index(List<UserActivity> activities)
    {
        if (ModelState.IsValid)
        {
            foreach( var activity in activities ) 
            {
                var first = _db.UserActivities
                      .FirstOrDefault(row => row.ActivityId == activity.ActivityId );
                if ( first == null ) {
                   _db.UserActivities.Add(activity);
                } else {
                   first.Duration = activity.Duration;
                   first.Date = activity.Date;
                }
            }
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        // when the ModelState is invalid, we want to 
        // retain posted values and display errors.
        return View(_db.Activities.ToList());
    }
