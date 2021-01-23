    public ActionResult MyPage(MyUrls? parameter = MyUrls.Url1)
    {
        if (!parameter.HasValue) {
           return HttpNotFound();
        }
        return View("MyView");
    }
