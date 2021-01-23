    cfg.CreateMap<MyViewModel, MyDbModel>()
        .ForMember(dest => dest.DbModelId, opt => opt.MapFrom(src => src.ViewModelId));
        
    cfg.CreateMap<ViewItem, IMyDbItem>()
        .ConstructUsing((ViewItem src) => new MyDbItem());
        
    cfg.CreateMap<IList<ViewItem>, IPageSelection>()
        .ConstructUsing((IList<ViewItem> src) => new PageSelection())
        .ForMember(dest => dest.PageSelections, opt => opt.MapFrom(src => src))
        .ForMember(dest => dest.PageNumber, opt => opt.Ignore());
