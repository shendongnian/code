        public ActionResult Index(ModelName model)
        {
            var items = // Your List of data
            model.ListName = items.Select(x=> new SelectListItem() {
                        Text = x.prop,
                        Value = x.prop2
                   });
        }
