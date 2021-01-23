    var coursesList = courses.DistinctBy(c => courses.Cours.Name)
                             .Select(crs => new SelectListItem
                                              {
                                                  Text = crs.Cours.Name,
                                                  Value = crs.Cours.ID.ToString()
                                              });
