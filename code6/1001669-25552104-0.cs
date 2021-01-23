    public static class MobileTeamModelExtensions
    {
      public static IEnumerable<MobileTeamModel> ToMobileTeamModels
        (this IQueryable<DivisionTeam> instance)
      {
        var result = instance.Select(e => 
          select new MobileTeamModel
                    {
                        Id = e.Id,
                        Name = e.Team.Name,
                        Status = e.Status,
                        Paid = e.Paid,
                        Division = e.Division.Name,
                        City = e.Team.TeamAddress.Address.City,
                        StateRegion =
                            e.Team.TeamAddress.Address.StateRegionId.HasValue
                                ? e.Team.TeamAddress.Address.StateRegion.Name
                                : null
                    }).ToList()
        return result;
      }
    }
