        public List<CityDTO> GetCities()
        {
            using (var db = new CitysDataEntities())
            {
                var cities = db.Cities;
                var query =
                (from city in cities
                 select new CityDTO
                     {
                        CityName = city.Name,
                         Trainstations = city.TrainStations.Select(ts => ts.Name).AsQueryable() // return AsQueryable
                     }).ToList();
                return query;
            }
        }
