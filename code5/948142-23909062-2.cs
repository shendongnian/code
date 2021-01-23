    public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
    {
        if (converter == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.converter);
        }
	
        List<TOutput> list = new List<TOutput>(this._size);
        
        for (int i = 0; i < this._size; i++)
        {
            list._items[i] = converter(this._items[i]);
        }
	
        list._size = this._size;
        return list;
    }
