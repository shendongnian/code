    public PageResult<DateSnippetWithDepartmentsViewModel> GetDatesWithDepartments(ODataQueryOptions<DateSnippet> options)
    {
        IQueryable query = options.ApplyTo(_context.DateSnippets, new ODataQuerySettings());;
        List<DateSnippet> dateSnippets = new List<DateSnippet>();
        foreach(DateSnippet item in query)
        {
            dateSnippets.Add(item);
        }
        var dateSnippetsViewModels = (from d in dateSnippets
                                        select new DateSnippetWithDepartmentsViewModel
                                        {
                                            ...
                                        });
        var result = new PageResult<DateSnippetWithDepartmentsViewModel>(
                dateSnippetsViewModels as IEnumerable<DateSnippetWithDepartmentsViewModel>,
                Request.GetNextPageLink(),
                Request.GetInlineCount());
        return result;
    }
