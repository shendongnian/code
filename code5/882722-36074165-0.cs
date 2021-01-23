    public ActionResult MyPage(MyUrls? parameter = MyUrls.Url1)
    {
        if (!parameter.HasValue) {
           return new HttpNotFoundResult();
        }
        return View("MyView");
    }
