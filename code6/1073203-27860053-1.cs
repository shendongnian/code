        public ActionResult Index()
        {
            var model = new TestModelViewModel
            {
                ParentList = new List<ParentListViewModel>
                {
                    new ParentListViewModel{
                        Id = 1,
                        Value = "One"
                    },new ParentListViewModel{
                        Id = 2,
                        Value = "Two"
                    },new ParentListViewModel{
                        Id = 3,
                        Value = "Three"
                    },
                }
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(TestModelViewModel model)
        {
            var ChildIds = model.ChildIds;
            /* now you can save these ChildIds to your db */
            return View(model);
        }
