    return this.Json(
              new
              {
                  Result = (from obj in db.Parkings
                                          .Where(p => p.BuildingId == myBuildingId)
                            select new
                            {
                                ID = obj.ID,
                                Name = obj.note
                            })
              }
              , JsonRequestBehavior.AllowGet
           );
