    public Book(string title, double price, int numberPages)
    {
       if(price / numberPages > 0.1)
          throw new BookException(title, price, numberPages);
    }
