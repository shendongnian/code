        public ActionResult EditSection(Int16 id = -1)
        {
            Section section = db.Sections.Find(id);
            if (section != null)
            {
                if (section.Type == "Collection")
                {
                    RedirectToAction("Collection", new { id = id });
                }
                SectionAddEditVM model = new SectionAddEditVM { Section = section };
                model.SelectedType = section.Type;
                return View(model);
            }
            else
            {
                section = new Section();
                SectionAddEditVM model = new SectionAddEditVM { Section = section };
                
                ModelState.AddModelError("Section ID", "Invalid Section ID");
                return View(model);
            }
        }
