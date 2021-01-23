        [HttpGet]
        public async Task<IActionResult> GetFoo()
        {
            return PartialView("_Foo", new Foo());
        }
