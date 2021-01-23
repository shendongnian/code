    public object Any(AnotherRequest request)
    {
        using (var service = base.ResolveService<GetSkillsService>())
        {
            List<SkillDto> results = service.Get(new GetSkillsList { ... });
        }
    } 
