    public object Convert(object value)
    { 
       int c;
       if(value is IBookRepository)
       {
          c = (int)((IBookRepository)value).CountAllBooks();
       }
       return c;
    }
