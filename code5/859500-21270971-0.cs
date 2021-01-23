	public Condo UpdateSheet(Condo condo) {
		Guard.IsNotNull(condo);
		List<long> retainedAmenityIds = (from amenity in condo.Amenities
										  where amenity.Id != 0
										  select amenity.Id).ToList();
		List<Amenity> retainedAmenities = (from amenity in condo.Amenities
											where amenity.Id != 0
											select amenity).ToList();
		string sql = String.Format("SELECT Id FROM {0} WHERE CondoId = {1}", GetTableName<Amenity>(), condo.Id);
		List<long> deletedAmenityIds = Database.SqlQuery<long>(sql).Except(retainedAmenityIds).ToList();
		if (0 < deletedAmenityIds.Count) {
			foreach (var id in deletedAmenityIds) {
				Amenity amenity = Amenities.Single(a => a.Id == id);
				Amenities.Remove(amenity);
			}
		}
		List<Amenity> addedAmenities = condo.Amenities.Except(retainedAmenities).ToList();
		foreach (var amenity in addedAmenities) {
			amenity.SheetId = condo.Id;
			Entry(amenity).State = EntityState.Added;
		}
		foreach (var amenity in retainedAmenities) { Entry(amenity).State = EntityState.Modified; }
		Entry(condo).State = EntityState.Modified;
		SaveChanges();
		return condo;
	}
