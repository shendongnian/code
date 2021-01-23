    var slipDets6 = (from s6 in db.Slips
                     join b6 in db.Boats on s6.BoatId equals b6.BoatId into temp
                     from jn in temp.DefaultIfEmpty()
                     orderby s6.SlipNumber
                     select new {s6, jn})
                     .ToList()
                     .Select(u => new
                         {
                             SlipID = (int?)u.s6.SlipId,
                             SlipNumber = u.s6.SlipNumber,
                             Length = u.s6.Length,
                             Electricity = u.s6.Electricity,
                             Telephone = u.s6.Telephone,
                             TV = u.s6.TV,
                             BoatDets = u.jn.BoatName + " [" + u.jn.BoatType + ", " + u.jn.BoatOverAllLength + "]",
                             Status = u.s6.Status
                         })
                     .ToList();
