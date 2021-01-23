    public IQueryable<TemplateDto> GetTemplates()
    {
        return db.TemplateModels.Include(t => t.Categories)
            .Select(CreateTemplateDTO(db));
    }
