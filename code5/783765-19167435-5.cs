    db.Schools.Where(x => x.name != null)
              .OrderBy(o => o.name).ToList()
              .Distinct(new SchoolComparer())
              .Select(s => new SelectListItem
                {
                    Value = MyTrimmings(s.name),
                    Text = MyTrimmings(s.name)
                });  
