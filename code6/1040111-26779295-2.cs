    [WebGet(UriTemplate = "GiveMeNamesOfStudents", ResponseFormat = WebMessageFormat.Json)]
    public ListResult<MyDataClass> GiveMeNamesOfStudentsList()
    {
        var returnData = (from myentity in myEntityRepository.AsQueryable()
                          select new MyDataClass
                            {
                                Id = myentity.Id,
                                Name = myentity.Name
                            }).Skip(PageSize * PageNo).Take(PageSize).ToList();
        return new ListResult<MyDataClass> 
                            { 
                                 Data = returnData, 
                                 TotalCount = myEntityRepository.Count(), 
                                 Page = PageNo 
                            };
    }
