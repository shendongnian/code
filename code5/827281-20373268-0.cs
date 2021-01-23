    public int CompareTo(Book book)
    {
        int result = Title.CompareTo(book.Title);
        if (result == 0)
        {
           result = Edition.CompareTo(book.Edition);
           if (result == 0)
           {
                result = Language.CompareTo(book.Language);
           }
        }
    
        return result;
    }
