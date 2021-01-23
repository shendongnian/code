       var model = db.School
              .Where(s => s.IsClosed == false)
              .OrderBy(s => s.Name)
              .Select(s => new SchoolIndex
              {
                  SchoolCode = s.Code,
                  School = s.Name,
                  LocalAuthority = s.LocalAuthority,
                  IsClosed = s.lIsClosed,
                  Address1 = s.Address1,
                  Address2 = s.Address2,
                  Address3 = s.Address3,
                  Address4 = s.Address4,
                  Address5 = s.Address5,
                  Postcode = s.Postcode
                  }
              }).ToPagedList(Page, 50);
