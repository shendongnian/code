    using (GeographyContext db = new GeographyContext())
            {
                GeographyTypes = new SelectList(db.GeographyTypes.Where(gt => gt.SectionID == SectionID), "ID", "Name").ToList();
            }
    
            return Json(new SelectList(GeographyTypes), JsonRequestBehavior.AllowGet);
