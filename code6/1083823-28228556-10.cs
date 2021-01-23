    public void DeleteFirstBook()
    {
    	var unitOfWork = new UnitOfWork(connnectionInformation);
    
    	var books = unitOfWork.BookRepository.GetAll();
    
    	if(books.Any())
    	{
    		unitOfWork.BookRepository.Delete(books.First());
    	}
    }
