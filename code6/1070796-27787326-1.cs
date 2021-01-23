    public T RequestAllPaginated<T, TK>() where T : Paginated<TK> where TK : class
    {
        var item = Request<T>();
    
        //Get all data from paging property
        if(item != null)
        {
            var i = item as Paginated<TK>;
            var data = i.data;
    
        }
    
        return item;
    }
