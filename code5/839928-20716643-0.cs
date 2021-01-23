    public object Convert(object value)
    {
       int c;
       if(value is IBookRepository)
       {
          c = (int)(value as IBookRepository).CountAllBooks(); //casting "object" to "IBookRepository"
       }
    }
