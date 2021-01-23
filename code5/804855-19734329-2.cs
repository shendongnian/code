    TModel MapToModel<TModel, TDto>(TDto dto, TModel model)
        where TModel : IConvertableModel<TDto>
    {
        model.SetFromDto(dto);
        return model;
    }
    // usage:
    var dto = _dtoRepository.GetFirstDto();
    return MapToModel(dto, new DisplayEditModel());
