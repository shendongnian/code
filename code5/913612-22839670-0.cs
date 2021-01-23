    AwardsListViewModel viewModel = AwardListViewModel
    {
         menuChild = repository
                       .menuChild
                       .Where(p => p.MenuParentAcronym == "Awards Processing" 
                                   && p.IsActive == "True")
                       .OrderBy(c => c.DisplayOrder)
                       .Select(m => m.Description == "Awards Processing List")
                       .ToList()
    };
