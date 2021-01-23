    var siteParam = Expression.Parameter(typeof(Site), "s");
    var cpeParam = Expression.Parameter(typeof(ContactPointEntity), "cpe");
    var selector = GetContactPoints<Site>(siteParam, cpeParam);
    return Context.Sites
        .Where(s => !s.IsDeleted && s.Vendor.Id == vendorId)
        .Select(selector)
        .Select(s => new SiteLabelDto
        {
            Id = s.Instance.Id,
            Name = s.Instance.Name,
            Email = s.Email,
            Phone = s.Phone
        })
        .ToArray();
