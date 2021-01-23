    IList<UserDto> result2 = (from x in result
                              // Here you group by User
                              group x by x.Id into y
                              let first = y.First()
                              // Here you build the "definitive" UserDto
                              select new UserDto {
                                  Nickname = first.Nickname,
                                  // and here you build the "definitive" CharacterDto
                                  // note the handling of empty objects!
                                  Characters = new List<CharacterDto>(y.Select(z => z.XP != null && z.ClassId != null ? new CharacterDto { XP = z.XP.Value, ClassId = z.ClassId.Value } : null))
                             )
                             .ToList();
    // remove empty CharacterDto from left join
    foreach (UserDto user in result) {
        if (user.Characters.Count == 1 && user.Characters[0] == null) {
            user.Characters.Clear();
        }
    }
