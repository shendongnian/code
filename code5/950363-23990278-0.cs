    _context.Database.SqlQuery<ProjectsModel>(
      "exec dbo.[GetProjectDetailsBySectorAndSubSector] @sectorId,@subSectorId", 
      new SqlParameter("@sectorId", sectorid),
      new SqlParameter("@subSectorId", subsectorid)
    ).ToList()
