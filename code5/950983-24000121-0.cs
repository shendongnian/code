      public async Task<IHttpActionResult> PutAsync([FromBody] WellEntityModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var kne = TheContext.Companies.First();
                var entity = TheModelFactory.Create(model);
                entity.DateUpdated = DateTime.Now;
                var currentWell = TheContext.Wells.Find(model.Id);
                // Update scalar/complex properties of parent
                TheContext.Entry(currentWell).CurrentValues.SetValues(entity);
                //We don't pass back the company so need to attached the associated company... this is done after mapping the values to ensure its not null.
                currentWell.Company = kne;
                // Updated geometry - ARGHHH NOOOOOO check on this once in a while for a fix from EF-Team https://entityframework.codeplex.com/workitem/864
                var geometryItemsInDb = currentWell.Geometries.ToList();
                foreach (var geometryInDb in geometryItemsInDb)
                {
                    // Is the geometry item still there?
                    var geometry = entity.Geometries.SingleOrDefault(i => i.Id == geometryInDb.Id);
                    if (geometry != null)
                        // Yes: Update scalar/complex properties of child
                        TheContext.Entry(geometryInDb).CurrentValues.SetValues(geometry);
                    else
                        // No: Delete it
                        TheContext.WellGeometryItems.Remove(geometryInDb);
                }
                foreach (var geometry in entity.Geometries)
                {
                    // Is the child NOT in DB?
                    if (geometryItemsInDb.All(i => i.Id != geometry.Id))
                        // Yes: Add it as a new child
                        currentWell.Geometries.Add(geometry);
                }
                // Update Surveys
                var surveyPointsInDb = currentWell.SurveyPoints.ToList();
                foreach (var surveyInDb in surveyPointsInDb)
                {
                    // Is the geometry item still there?
                    var survey = entity.SurveyPoints.SingleOrDefault(i => i.Id == surveyInDb.Id);
                    if (survey != null)
                        // Yes: Update scalar/complex properties of child
                        TheContext.Entry(surveyInDb).CurrentValues.SetValues(survey);
                    else
                        // No: Delete it
                        TheContext.WellSurveyPoints.Remove(surveyInDb);
                }
                foreach (var survey in entity.SurveyPoints)
                {
                    // Is the child NOT in DB?
                    if (surveyPointsInDb.All(i => i.Id != survey.Id))
                        // Yes: Add it as a new child
                        currentWell.SurveyPoints.Add(survey);
                }
                // Update Temperatures - THIS IS A HUGE PAIN = HOPE EF is updated to handle updating disconnected graphs.
                var temperaturesInDb = currentWell.Temperatures.ToList();
                foreach (var tempInDb in temperaturesInDb)
                {
                    // Is the geometry item still there?
                    var temperature = entity.Temperatures.SingleOrDefault(i => i.Id == tempInDb.Id);
                    if (temperature != null)
                        // Yes: Update scalar/complex properties of child
                        TheContext.Entry(tempInDb).CurrentValues.SetValues(temperature);
                    else
                        // No: Delete it
                        TheContext.WellTemperaturePoints.Remove(tempInDb);
                }
                foreach (var temps in entity.Temperatures)
                {
                    // Is the child NOT in DB?
                    if (surveyPointsInDb.All(i => i.Id != temps.Id))
                        // Yes: Add it as a new child
                        currentWell.Temperatures.Add(temps);
                }
                await TheContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return InternalServerError();
        }
 
