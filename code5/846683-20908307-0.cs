    public ActionResult Details(int id)
    {
      yourRepositary.MarkMessageAsRead(id);
      var messageVM=yourService.GetMessage(id);
      return View(messageVM);
    }
