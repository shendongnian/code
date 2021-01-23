    UserCharacterDto uc = null;
    .Select(
            Projections.Property(() => userAlias.Nickname).WithAlias(() => uc.Nickname),
            Projections.Property(() => characterAlias.XP).WithAlias(() => uc.XP),
            Projections.Property(() => characterAlias.ClassId).WithAlias(() => uc.ClassId)
        )
    .TransformUsing(Transformers.AliasToBean<UserDto>())
    .Take(50)
    .List<UserCharacterDto>()
    
    // Here you group by User
    .GroupBy(x => x.Id)
    // Here you build the "definitive" UserDto
    .Select(x => new UserDto {
        Nickname = x.First().Nickname,
        // and here you build the "definitive" CharacterDto
        Characters = new List<CharacterDto>(x.Select(y => new CharacterDto { XP = y.XP, ClassId = y.ClassId }))
    }).ToList(); // List<UserDto>
