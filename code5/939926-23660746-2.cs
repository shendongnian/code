    internal virtual IQueryable<TDto> BuildListQueryUntracked(TemplateWebAppDb context)
    {
        Mapper.CreateMap<TData, TDto>();
        return context.Set<TData>().AsNoTracking().Project().To<TDto>();
    }
