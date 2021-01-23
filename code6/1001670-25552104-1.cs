    var query = _divisionsRepository.DataContext.DivisionTeams
      .Where(@where.Expand());
    var list = query.ToMobileTeamModels();
    var query = query.Where(<more where>);
    var list2 = query.ToMobileTeamModels();
