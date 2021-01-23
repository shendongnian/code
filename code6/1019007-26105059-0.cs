    public SiteLabelDto[] GetVendorSites(int vendorId)
    {
        return (from s in Context.Sites
             where !s.IsDeleted && s.Vendor.Id == vendorId
             let email = s.ContactPoints.FirstOrDefault(x => x.Type == ContactPointType.Email) 
             let phone = s.ContactPoints.FirstOrDefault(x => x.Type == ContactPointType.Phone)
            select new SiteLabelDto
            {
                Id = s.Id,
                Name = s.Name,                    
                Address = s.Address.StreetAddress + ", " + s.Address.Locality + ", " + s.Address.Region + ", " + s.Address.Postcode,
                Country = s.Address.Country.Name,
                Email = email  != null ? email.Value : "",
                Phone = phone != null ? phone .Value : "",
            }).ToArray();
    }
