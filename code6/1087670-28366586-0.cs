        [HttpPost]
        public ActionResult TestAction(Model model)
        {
            var entityA = _mappingService.Map<Model, EntityA>(model);
            testService.TestMethod(entityA);
            
            return View();
        }
