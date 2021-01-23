    AwardsListViewModel viewModel = AwardListViewModel
    {
         menuChild = repository
                       .menuChild
                       .Where(p => p.MenuParentAcronym == "Awards Processing" 
                                   && p.IsActive == "True")
                                   && p.Description == "Awards Processing List")
                       .OrderBy(c => c.DisplayOrder)
    };
