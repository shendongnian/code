    IList<UserDto> result2 = (from x in result
                              // Here you group by User
                              group x by x.Id into y
                              let first = y.First()
                              // Here you build the "definitive" UserDto
                              select new UserDto {
                                  Nickname = first.Nickname,
                                  // and here you build the "definitive" CharacterDto
                                  Characters = new List<CharacterDto>(y.Select(z => new CharacterDto { XP = z.XP, ClassId = z.ClassId }))
                             )
                             .ToList();
