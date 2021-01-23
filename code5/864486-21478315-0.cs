        [ChildActionOnly]
        public ActionResult VariantsDdl()
        {
            long defaultVariantID;
            long.TryParse(System.Configuration.ConfigurationManager.AppSettings["DefaultVariantId"], out defaultVariantID);
            if (System.Web.HttpContext.Current.Session["mySelectedVariant"] != null)
            {
                long.TryParse(System.Web.HttpContext.Current.Session["mySelectedVariant"].ToString(), out defaultVariantID);
            }
            var variants = this.db.warianties.ToList();
            var items = new List<SelectListItem>();
            foreach (var variant in variants)
            {
                var selectedItem = false;
                if(variant.id == defaultVariantID)
                {
                    selectedItem = true;
                }
                items.Add(new SelectListItem { Selected = selectedItem, Text = variant.nazwa, Value = variant.id.ToString() });
            }
            return this.PartialView("~/Views/Shared/Partials/VariantsDdlPartial.cshtml", items);
        }
