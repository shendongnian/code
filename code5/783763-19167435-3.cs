    db.Schools.Where(x => x.name != null)
              .Distinct(new SchoolComparer())
              .OrderBy(o => o.name)
              .Select(s => new SelectListItem
                {
                    Value = MyTrimmings(s.name),
                    Text = MyTrimmings(s.name)
                }).ToList();  
