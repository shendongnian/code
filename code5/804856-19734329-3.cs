    TModel CreateModel<TModel, TDto>(TDto dto)
        where TModel : IConvertableModel<TDto>, new()
    {
        var model = new TModel();
        return MapToModel(dto, model);
    }
    // usage:
    var dto = _dtoRepository.GetFirstDto();
    return CreateModel<DisplayEditModel>(dto);
