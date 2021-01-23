     public IEnumerable<StudentBaseModel> Get(int page = 0, int pageSize = 10)
    {
        IQueryable<Student> query;
 
        query = TheRepository.GetAllStudentsWithEnrollments().OrderBy(c => c.LastName);
 
        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
 
        var urlHelper = new UrlHelper(Request);
        var prevLink = page > 0 ? urlHelper.Link("Students", new { page = page - 1, pageSize = pageSize }) : "";
        var nextLink = page < totalPages - 1 ? urlHelper.Link("Students", new { page = page + 1, pageSize = pageSize }) : "";
 
        var paginationHeader = new
        {
            TotalCount = totalCount,
            TotalPages = totalPages,
            PrevPageLink = prevLink,
            NextPageLink = nextLink
        };
 
        System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination",
        Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
 
        var results = query
        .Skip(pageSize * page)
        .Take(pageSize)
        .ToList()
        .Select(s => TheModelFactory.CreateSummary(s));
 
        return results;
    }
