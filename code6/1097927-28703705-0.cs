    var adressen = adresRepository
                    .Query(r => r.RelatieId == relatieId)
                    .Include(i => i.AdresType)
                    .Select().ToList();
    
    var adresids = (from a in adressen select a.AdresId).ToList();
                IRepositoryAsync<Comm> commRepository = unitOfWork.RepositoryAsync<Comm>();
                
                var comms = commRepository
                    .Query(c => adresids.Contains(c.AdresId))
                    .Include(i => i.CommType)
                    .Select();
                
