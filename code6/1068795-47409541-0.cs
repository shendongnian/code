                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem
                {
                    Text = "car",
                    Value = "car"
                });
                ViewBag.List = new SelectList(items, "Text", "Value");
