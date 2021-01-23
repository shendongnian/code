    var idList = new List<int> { 1,2,3 };
    dbContext.MyList.Where(x => idList.Contains(x.ID))
                    .ToList()
                    .ForEach(x => x.Archived = true);
    dbContext.SaveChanges();
