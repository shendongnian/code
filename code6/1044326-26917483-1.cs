    static destination ConstructDestination(source src)
    {
        List<string> chunked = src.Value
            .Select((ch, index) => new { Character = ch, Index = index })
            .GroupBy(
                grp => grp.Index / 10,
                (key, grp) => new string(grp.Select(itm => itm.Character).ToArray()))
            .ToList();
            
        var dest = new destination
        {
            Value1 = chunked.Count > 0 ? chunked[0] : null,
            Value2 = chunked.Count > 1 ? chunked[1] : null,
            Value3 = chunked.Count > 2 ? chunked[2] : null
        };
            
        return dest;
    }
    Mapper.CreateMap<source, destination>()
        .ConstructUsing(ConstructDestination)
        .ForMember(dest => dest.Value1, opt => opt.Ignore())
        .ForMember(dest => dest.Value2, opt => opt.Ignore())
        .ForMember(dest => dest.Value3, opt => opt.Ignore());
        /* Id is mapped automatically. */
