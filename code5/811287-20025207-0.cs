    private IEnumerable<int> AddLocationEntities(IEnumerable<LocationDataModel> locations)
        {
            var results = new List<int>();
            foreach (LocationDataModel l in locations)
            {
                var entity = _mapper.Map<LocationDataModel, Location>(l);//you can map manually also
                var AttributeCode = l.AssignedAttributes.FirstOrDefault().AttributeTypeId;
                using (MyContext c = new MyContext())
                {
                    var attr = c.AttributeTypes.Where(a => a.Id == AttributeTypeId ).ToList();
                    entity.AttributeTypes = attr;
                    c.Locations.Add(entity);
                    c.SaveChanges();
                    var locid = entity.Id;
                    results.Add(locid);
                }
            }
          return results;
        }
    
