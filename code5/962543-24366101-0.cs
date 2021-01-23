    .ForMember(
        destination => destination.Nickname,
        option => 
        {
            option.Condition(resolutionContext =>
                (resolutionContext.InstanceCache.First().Value as ProfileViewModel).NicknameIsVisible);
            option.MapFrom(source => source.Nickname);
        }
    );
