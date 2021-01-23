    var userId = new Guid("...");
    var websiteGuid = new Guid("...");
    var _repository = new Repository<Website>(this);
    
    var website = _repository
    .Query()
    .Select()
    .Single(u => u.UserId == userId && u.WebsiteGuid == websiteGuid);
    
    website
    .Dump();
