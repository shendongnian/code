    var model = _userGroupAssignmentRepository.Table
        .Join(_userGroupsRepository.Table,
            x => x.groupId,
            y => y.Id,
            (x, y) => new { Assignment = x, Group = y })
        .Where(xy => xy.Group.GrpName == name)
        .Select(xy => new UserGroupAssignmentModel(/*pass params here*/)
                      {
                          // or set properties here
                      })
        .ToList();
