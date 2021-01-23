    public IList<Book> GetBooksFields(string propertyName, string propertyValue)
    {
    	 var parameter = Expression.Parameter(typeof(Book), "book");
    	 
    	 var left = Expression.Property(parameter, propertyName);	
         var convertedValue = Convert.ChangeType
                              ( 
                                  propertyValue, 
                                  typeof(Book).GetProperty(propertyName).PropertyType
                              );
    	 var right = Expression.Constant(convertedValue);
    			
    	 var binaryExpr = Expression.Equal(left, right);    	
    	 var expr = Expression.Lambda<Func<Book, bool>>(binaryExpr, parameter);    	
      	
    	 return bookRepository.GetMany(expr).ToList();        	
    }
