        public ActionResult Edit([Bind(Include = "ID,Name,Images")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                for (var i = 0; i < survey.Images.Count; i++ )
                {
                    if ((survey.Images[i].SurveyID == 0) && (survey.Images[i].ImageID == 0))
                    {
                        survey.Images[i].SurveyID = survey.ID;
                        db.Images.Add(survey.Images[i]);
                    }
                }
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }
