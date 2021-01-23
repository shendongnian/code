    public ActionResult Edit(int? id)
    {
        // other code
        var options = new List<SelectListItem>();
        foreach (var p_itmes in Prov)
        {
            var item = new SelectListItem();
            if (mid_list.Contains(p_itmes.ID))
                item.Selected = true;
            item.Value = p_itmes.ID.ToString();
            item.Text = p_itmes.Name;
            options.Add(item);
        }
        ViewBag.options = options;
        return View(edata);
    }
