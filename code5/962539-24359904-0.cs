    Mapper.CreateMap<UserDetails, ProfileViewModel>()
    .ForMember(
            destination => destination.Nickname,
            option => 
            {
                option.Condition(rc => 
                    var profileViewModel = (ProfileViewModel)rc.DestinationValue;
                    return profileViewModel.NicknameIsVisible;
                );
                option.MapFrom(source => source.Nickname);
            }
    );
