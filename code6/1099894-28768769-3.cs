    UserCharacterDto uc = null;
    
    IList<UserCharacterDto> result = ...
        .Select(
            Projections.Property(() => userAlias.Nickname).WithAlias(() => uc.Nickname),
            Projections.Property(() => characterAlias.XP).WithAlias(() => uc.XP),
            Projections.Property(() => characterAlias.ClassId).WithAlias(() => uc.ClassId)
        )
        .TransformUsing(Transformers.AliasToBean<UserDto>())
        .Take(50)
        .List<UserCharacterDto>()
