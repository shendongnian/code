    var dto2 = rd.EngDetailBitsList(dto.EngId).Cast<IDto>();
    var dto3 = rd.EngDetailDateTimesList(dto.EngId).Cast<IDto>();
    var dto4 = rd.EngDetailVarCharsList(dto.EngId).Cast<IDto>();
    var dto5 = rd.EngDetailVarCharMaxesList(dto.EngId).Cast<IDto>();
    SetValues(dto, dto2);
    SetValues(dto, dto3);
    SetValues(dto, dto4);
    SetValues(dto, dto5);
