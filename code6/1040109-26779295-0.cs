     public class ListResult<T>
     {
         public List<T> Data { get; set; }
         public int TotalCount { get; set; }
         public int Page{ get; set; }
     }
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
