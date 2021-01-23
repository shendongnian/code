    ViewModel.Model = MyDbContext.usp_ModelA_GetByID(AId).Single();
    var Details = 
    (from b in MyDbContext.usp_ModelB_GetByID(BId)
    join c in MyDbContext.usp_ModelC_GetAll()
       on b.CId equals c.CId
    select new ModelB()
    {
        BId = b.BId,
        CId = b.CId,
        C = c
    }).ToList();  
    //ToList() executes the proc and projects the plate details into the object 
    //graph which never tries to select from the database because LazyLoadingEnabled is
    //false.  Then, the magical relationship fix-up allows me to traverse my object graph
    //using ViewModel.Model.ModelBs which returns all of the ModelBs loaded into the graph
    //that are related to my ModelA.
