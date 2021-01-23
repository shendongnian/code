     public IEnumerable<ViewModel.BookViewModel> BookList() 
    { 
        List<ViewModel.BookViewModel> res=base.GetAll().Select(x => new ViewModel.BookViewModel { 
                                    ID=x.ID, 
                                    Name=x.Name 
                                  }).ToList(); 
    return res; 
    }
