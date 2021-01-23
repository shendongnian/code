    Mapper.CreateMap<UserDetails, ProfileViewModel>()
    .ForMember(
            destination => destination.Nickname,
            option => 
            {
                option.Condition(rc => 
                {
                    var profileViewModel = (ProfileViewModel)rc.InstanceCache.First().Value;
                    return profileViewModel.NicknameIsVisible;
                });
                option.MapFrom(source => source.Nickname);
            }
    );
