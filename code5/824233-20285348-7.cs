    public ActionResult EditBodyStyle(int bodyStyleId)
    {
        var styles = BodyStyles.Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.Name,
                        Selected = bodyStyleId.Equals(m.Id.ToString())
        
                    });
        ViewBag.Styles = styles;
        return View(model);
    }
