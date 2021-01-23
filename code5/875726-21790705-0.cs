    repository
        .Stub(repo => repo.GetPaged(
            Arg<string>.Is.Anything, 
            Arg<string>.Is.Anything,  
            Arg<int>.Is.Anything, 
            Arg<int>.Is.Anything, 
            Arg<string>.Is.Anything))
        .Return(new ContentList<Entities.Customer> { List = IQueryableList, Total = customerList.Count });
