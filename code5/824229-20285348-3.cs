    public ActionResult EditBodyStyle(Car model)
    {
        BodyStyleId = model.BodyStyleId; 
        var styles = BodyStyles.Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.Name,
                        Selected = BodyStyleId.Equals(m.Id.ToString())
        
                    });
        ViewBag.Styles = styles;
        return View(model);
    }
