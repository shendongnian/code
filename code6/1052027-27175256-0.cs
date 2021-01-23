         // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var edata = db.Projects.Find(id);
            //check if data
            if (edata == null)
                return HttpNotFound();
            //IEnumerable<SelectListItem> items = db.Provinces.Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name });
            //ViewBag.ProvinceId = items;
            //---Get all provice-----
            var Prov = from c in db.Provinces select c;
            //------get province ids---------------
            var prov_id = from o in db.ProRel where o.ProjectId == id select o.ProvinceIds;
            List<int> mid_list = new List<int>();
            foreach (var p_ids in prov_id)
            {
                mid_list.Add(p_ids);
            }
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
