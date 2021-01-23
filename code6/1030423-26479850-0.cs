    TDAL tda = new TDAL();
            //////////////////////
            List<SelectListItem> list= new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "All", Value = "0" });
            var cat = tda.getCountries().ToArray();
            for (int i = 0; i < cat.Length; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = cat[i].citizenship,
                    Value = cat[i].citizenship.ToString(),
                    Selected = (cat[i].citizenship == "1")
                 });
            }
            ViewData["citizen"] = list;
            ////////////////////////////
            return View();
