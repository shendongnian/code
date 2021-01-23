        public ActionResult Index()
        {
            var test = new TestViewModel();
            test.ModelData = new List<TestViewModel.InnerViewModel>()
            {
                new TestViewModel.InnerViewModel {Id = 10},
                new TestViewModel.InnerViewModel {Id = 20},
                new TestViewModel.InnerViewModel {Id = 30},
                new TestViewModel.InnerViewModel {Id = 40}
            };
            return View(test);
        }
        public string TestAction(TestViewModel model)
        {
            string s = "";
            foreach (TestViewModel.InnerViewModel innerViewModel in model.ModelData)
            {
                if (innerViewModel.Checked)
                    s += innerViewModel.Id + " ";
            }
            return s;
        }
