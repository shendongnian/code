	public static IQueryable<SiteDTO> MapToSiteDTO(this IQueryable<Site> query)
	{
		return query.Select(s => new SiteLabelDto
								{
									Id = s.Id,
									Name = s.Name,                    
									Address = s.Address.StreetAddress + ", " + s.Address.Locality + ", " + s.Address.Region + ", " + s.Address.Postcode,
									Country = s.Address.Country.Name,
									Email = s.ContactPoints.FirstOrDefault(x => x.Type == ContactPointType.Email) != null ? s.ContactPoints.FirstOrDefault(x => x.Type == ContactPointType.Email).Value : "",
									Phone = s.ContactPoints.FirstOrDefault(x => x.Type == ContactPointType.Phone) != null ? s.ContactPoints.FirstOrDefault(x => x.Type == ContactPointType.Phone).Value : "",                    
								});
	}
