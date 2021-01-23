    return Json(new
        {
            name = "Sites",
            children = results.GroupBy(site => site.Type).Select(group => new
            {
                name = group.Key,
                children = group
            }
        },
        JsonRequestBehavior.AllowGet);
