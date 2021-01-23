    Book book = DbContext.Books.Single(book => book.Id == viewModel.NewStudent.Favorite.Id);
    if(book!=null)
    {
        viewModel.NewStudent.Favorite = book;
    }
    else
    {
        throw new Exception();
    }
    DbContext.Add(viewModel.NewStudent);
    DbContext.SaveChanges();
