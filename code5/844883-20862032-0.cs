        [ChildActionOnly]
        [Route("DataView")]
        public PartialViewResult DataView()
        {
            var model = new DataViewModel(repository);
            return PartialView("DataView", model);
        }
