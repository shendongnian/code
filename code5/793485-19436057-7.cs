    public CategoryService : ICategoryService
    {
    	public Category GetByName(string name)
    	{
    		return _categoryRepository.Table
    								  .Include(c => c.Products)	// Include related products
    								  .FirstOrDefault(c => c.UrlName = name);
    	}
    }
