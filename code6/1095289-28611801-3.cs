    IList<ToursAvail2VM> toursvm =
                    (from vm in
                        (from t in db.Tours
                         join d in db.TourDates on t.TourId equals d.TourId
                         join c in db.TourCategories on t.TourCategoryId equals c.TourCategoryId
                         where d.Date == dte && t.TourCategoryId == id
                         select new
                        {
                            Id = t.TourId,
                            TourName = t.TourName,
                            TourCategoryId = t.TourCategoryId,
                            Bookings = db.Bookings.Where(b => d.TourDateId == b.TourDateId).Count()                            
                        }).ToList()
                    select new ToursAvail2VM
                        {
                             Id = vm.Id,
                             TourName = vm.TourName,
                             TourCategoryId = vm.TourCategoryId,
                             Bookings = vm.Bookings
                        }).ToList();
