        [HttpPost]
        public ActionResult Edit([Bind(Include = "SectionID, SectionName, Note")]Section sectionObject)
        {
...
  
