        [HttpPost]
        public ActionResult Index(ParentViewModel model)
        {
            try
            {
                var dto = new ParentThingDTO(model);
                var parentThing = dto.GenerateEntity();
                using (var context = new QuantumContext())
                {
                    context.ParentThings.Add(parentThing);
                    context.SaveChanges();
                    model.Message = "Saved";
                }
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View(model);
        }
